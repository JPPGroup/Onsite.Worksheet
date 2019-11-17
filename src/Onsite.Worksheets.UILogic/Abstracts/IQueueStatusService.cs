using System;

namespace Onsite.Worksheets.UILogic.Abstracts
{
    //TODO: add xml comments
    public interface IQueueStatusService
    {
        event EventHandler StatusChanged;

        QueueStatus Status { get; }
    }
}
