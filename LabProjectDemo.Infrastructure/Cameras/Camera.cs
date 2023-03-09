using LabProjectDemo.Core.Entities;
using LabProjectDemo.Core.Interfaces.Cameras;
using LabProjectDemo.Core.Interfaces.Markcodes;
using LabProjectDemo.Infrastructure.Interfaces;

namespace LabProjectDemo.Infrastructure.Cameras
{
    public abstract class Camera
    {
        protected readonly ICameraNetworkModule _cameraNetworkModule;     // CameraTCPConnector
        protected readonly ICameraCodeDecoder _codeDecoder;               // CameraCodeDecoderService
        
        protected readonly IMainView _viewController;               // Какой-то класс из view

        public Camera(ICameraNetworkModule cameraNetworkModule,
            ICameraCodeDecoder codeDecoder, IMainView viewController)
        {
            _cameraNetworkModule = cameraNetworkModule;
            _codeDecoder = codeDecoder;
            _viewController = viewController;
        }

        public void Connect()
        {
            _cameraNetworkModule.Connect();
        }

        public string[] GetCode()
        {
            return _codeDecoder.Decode(_cameraNetworkModule.GetEncodedCode());
        }
    }
}
