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
        
        protected readonly IVeiwController _viewController;               // Какой-то класс из view

        public Camera(ICameraNetworkModule cameraNetworkModule,
            ICameraCodeDecoder codeDecoder, IVeiwController viewController)
        {
            _cameraNetworkModule = cameraNetworkModule;
            _codeDecoder = codeDecoder;
            _viewController = viewController;
        }

    }
}
