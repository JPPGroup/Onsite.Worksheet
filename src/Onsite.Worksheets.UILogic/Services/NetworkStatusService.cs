using Onsite.Worksheets.UILogic.Managers;
using System;
using Onsite.Worksheets.UILogic.Abstracts;

namespace Onsite.Worksheets.UILogic.Services
{
    public sealed class NetworkStatusService : INetworkStatusService
    {
        private readonly INetworkManager _networkManager;

        public event EventHandler StatusChanged;

        public NetworkStatus Status => _networkManager.IsInternet ? NetworkStatus.Connected : NetworkStatus.Disconnected;

        public NetworkStatusService(INetworkManager manager)
        {
            _networkManager = manager;
            _networkManager.OnConnectivityChanged += NetworkManagerOnOnConnectivityChanged;
        }

        private void NetworkManagerOnOnConnectivityChanged(object sender, EventArgs e)
        {
            OnStatusChanged(e);
        }

        private void OnStatusChanged(EventArgs e)
        {
            StatusChanged?.Invoke(Status, e);
        }
    }
}
