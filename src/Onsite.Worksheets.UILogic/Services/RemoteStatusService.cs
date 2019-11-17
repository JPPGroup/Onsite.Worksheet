using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Onsite.Worksheets.UILogic.Abstracts;

namespace Onsite.Worksheets.UILogic.Services
{
    public sealed class RemoteStatusService : IRemoteStatusService
    {
        private const int THRESHOLD = 5;

        private int _cancelledTaskCount;
        private bool _isTerminal;
        private bool _isRequestError;
        private Guid? _resetGuid;

        public event EventHandler StatusChanged;
        public event EventHandler ThresholdReached;

        public RemoteStatus Status { get; private set; } = RemoteStatus.Ok;
        public Stack<Exception> ErrorStack { get; }

        public RemoteStatusService()
        {
            ErrorStack = new Stack<Exception>();
        }

        public Task SuccessfulRequest()
        {
            return Task.Run(() =>
            {
                if (Status != RemoteStatus.Failing) return;
                _cancelledTaskCount -= 1;
                SetStatus();
            });
        }

        public Task FailedRequest(Exception ex)
        {
            return Task.Run(() =>
            {
                ErrorStack.Push(ex);

                switch (ex)
                {
                    case TaskCanceledException _:
                        break;
                    case HttpRequestException _:
                        _isRequestError = true;
                        break;
                    default:
                        _isTerminal = true;
                        break;
                }

                _cancelledTaskCount += 1;
                SetStatus();
            });
        }

        public Task Reset(Guid resetGuid)
        {
            return Task.Run(() =>
            {
                if (resetGuid != _resetGuid) return;

                _cancelledTaskCount = 0;
                _isRequestError = false;
                _resetGuid = null;

                SetStatus();
            });
        }

        private void SetStatus()
        {
            var newStatus = RemoteStatus.Ok;

            if (_isTerminal)
            {
                newStatus = RemoteStatus.Terminal;
            }
            else if (_cancelledTaskCount >= THRESHOLD || _isRequestError)
            {
                newStatus = RemoteStatus.Unavailable;
            }
            else if (_cancelledTaskCount < THRESHOLD && _cancelledTaskCount > 0)
            {
                newStatus = RemoteStatus.Failing;
            }

            if (Status == newStatus) return;

            Status = newStatus;
            OnStatusChanged(new EventArgs());

            if (Status == RemoteStatus.Unavailable) OnThresholdReached(new EventArgs());
        }

        private void OnStatusChanged(EventArgs e)
        {
            StatusChanged?.Invoke(Status, e);
        }

        private void OnThresholdReached(EventArgs e)
        {
            if (_resetGuid != null) return;

            _resetGuid = Guid.NewGuid();
            ThresholdReached?.Invoke(_resetGuid, e);
        }
    }
}
