namespace LabProjectDemo.Core.Interfaces
{
    public interface INetworkConnector
    {
        public void Connect();
        public void Disconnect();
        public void CheckConnectionStatus();
    }
}
