using System;

namespace Onsite.Worksheets.UILogic.Abstracts
{
    //TODO: add xml comments
    public interface INetworkStatusService
    {
        event EventHandler StatusChanged;

        NetworkStatus Status { get; }
    }
}
