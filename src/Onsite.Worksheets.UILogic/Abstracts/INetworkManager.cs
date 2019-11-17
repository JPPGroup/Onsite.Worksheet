using System;

namespace Onsite.Worksheets.UILogic.Abstracts
{
    //TODO: add xml comments
    public interface INetworkManager
    {
        event EventHandler OnConnectivityChanged;
        bool IsInternet { get; }
    }
}
