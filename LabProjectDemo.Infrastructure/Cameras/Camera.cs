using LabProjectDemo.Core.Interfaces;
using LabProjectDemo.Core.Interfaces.Cameras;

namespace LabProjectDemo.Infrastructure.Cameras
{
    public class Camera : IMarkcodeDevice
    {
        protected readonly ICameraNetworkModule _cameraNetworkModule;     // CameraTCPConnector
        protected readonly ICameraCodeDecoder _codeDecoder;               // CameraCodeDecoderService

        public Camera(ICameraNetworkModule cameraNetworkModule,
            ICameraCodeDecoder codeDecoder)
        {
            _cameraNetworkModule = cameraNetworkModule;
            _codeDecoder = codeDecoder;
        }
        public void StartWork()
        {
            _cameraNetworkModule.Connect();
        }

        public void StopWork()
        {
            _cameraNetworkModule.Disconnect();
        }

        public string[] GetCodes()
        {
            return _codeDecoder.Decode(_cameraNetworkModule.GetEncodedCode());
        }
    }
}
