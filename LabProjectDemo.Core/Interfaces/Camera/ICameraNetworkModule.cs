namespace LabProjectDemo.Core.Interfaces.Camera
{
    public interface ICameraNetworkModule : INetworkConnector
    {
        public string GetEncodedCode();
    }
}
