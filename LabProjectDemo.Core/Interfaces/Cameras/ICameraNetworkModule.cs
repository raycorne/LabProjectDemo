namespace LabProjectDemo.Core.Interfaces.Cameras
{
    public interface ICameraNetworkModule : INetworkConnector
    {
        public string GetEncodedCode();
    }
}
