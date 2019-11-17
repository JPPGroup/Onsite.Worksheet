using System;
using Onsite.Worksheets.UILogic.Abstracts;

namespace Onsite.Worksheets.UILogic.Services
{
    public sealed class QueueStatusService : IQueueStatusService
    {
        private bool _hasItems;

        public event EventHandler StatusChanged;

        public QueueStatus Status => _hasItems ? QueueStatus.Sync : QueueStatus.Empty;
        public bool HasItems
        {
            get => _hasItems;
            set
            {
                if (value == _hasItems) return;

                _hasItems = value;
                OnStatusChanged(new EventArgs());
            }
        }

        private void OnStatusChanged(EventArgs e)
        {
            StatusChanged?.Invoke(HasItems, e);
        }
    }
}
