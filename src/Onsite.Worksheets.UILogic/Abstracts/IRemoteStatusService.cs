using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Onsite.Worksheets.UILogic.Abstracts
{
    //TODO: add xml comments
    public interface IRemoteStatusService
    {
        event EventHandler StatusChanged;
        event EventHandler ThresholdReached;

        RemoteStatus Status { get; } 
        Stack<Exception> ErrorStack { get; }

        Task SuccessfulRequest();
        Task FailedRequest(Exception ex);
        Task Reset(Guid resetGuid);
    }
}
