namespace LabProjectDemo.Core.Interfaces
{
    public interface INetworkConnector
    {
        public void Connect(string ip, int port);
        public void Disconnect();
        public void CheckConnectionStatus();
    }
}
