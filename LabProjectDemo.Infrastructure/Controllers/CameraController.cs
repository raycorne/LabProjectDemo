using LabProjectDemo.Core.Interfaces;
using LabProjectDemo.Core.Interfaces.Camera;
using LabProjectDemo.Core.Interfaces.MarkcodeFolder;
using LabProjectDemo.Infrastructure.Interfaces;

namespace LabProjectDemo.Core
{
    public class CameraController : ICameraController
    {
        private readonly ICameraNetworkModule _cameraNetworkModule;     // CameraTCPConnector
        private readonly ICameraCodeDecoder _codeDecoder;               // CameraCodeDecoderService
        private readonly IMarkcodeService _markcodeService;             // MarkcodeService
        private readonly IVeiwController _viewController;               // Какой-то класс из view
        public CameraController(ICameraNetworkModule cameraConnector, ICameraCodeDecoder codeDecoder, 
            IMarkcodeService markcodeService, IVeiwController viewController)
        {
            _cameraNetworkModule = cameraConnector;
            _codeDecoder = codeDecoder;
            _markcodeService = markcodeService;
            _viewController = viewController;
        }

        public void StartWork()
        {
            // Создается поток (ну или потоки, если камер несколько)
            // 
            throw new NotImplementedException();
        }

        public void StopWork()
        {
            throw new NotImplementedException();
        }
    }
}
