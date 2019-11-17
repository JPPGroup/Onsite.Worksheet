using System;
using Windows.Networking.Connectivity;
using Onsite.Worksheets.UILogic.Abstracts;

namespace Onsite.Worksheets.UILogic.Managers
{
    public class NetworkManager : INetworkManager
    {
        public event EventHandler OnConnectivityChanged;

        public bool IsInternet
        {
            get
            {
                var connections = NetworkInformation.GetInternetConnectionProfile();
                var internet = connections != null && connections.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess;
                return internet;
            }
        }

        public NetworkManager()
        {
            NetworkInformation.NetworkStatusChanged += NetworkInformationOnNetworkStatusChanged;
        }

        private void NetworkInformationOnNetworkStatusChanged(object sender)
        {
            OnConnectivityChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
