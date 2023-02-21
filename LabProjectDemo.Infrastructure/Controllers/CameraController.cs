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

        private Thread _thread;
        public bool isWorking { get; private set; } = false;

        public CameraController(ICameraNetworkModule cameraConnector, ICameraCodeDecoder codeDecoder, 
            IMarkcodeService markcodeService, IVeiwController viewController)
        {
            _cameraNetworkModule = cameraConnector;
            _codeDecoder = codeDecoder;
            _markcodeService = markcodeService;
            _viewController = viewController;
        }

        public void StartCameraThread()
        {
            _thread = new Thread(StartCameraWork);
            _thread.Start();
        }

        private async void StartCameraWork()
        {
            isWorking = true;
            try
            {
                _cameraNetworkModule.Connect("", 23);
                while (isWorking)
                {
                    string[] decodedCodes = _codeDecoder.Decode(_cameraNetworkModule.GetEncodedCode());
                    if (_codeDecoder.isCodesCorrected(decodedCodes))
                    {
                        await Task.Run(() => AddCodes(decodedCodes.Take(decodedCodes.Length).ToArray()));
                    }
                }
            } catch (Exception ex)
            {

            }
        }

        public void AddCodes(string[] codes)
        {
            foreach (string code in codes)
            {
                _markcodeService.AddMarkcode(new Entities.Markcode(Guid.NewGuid().ToString(), code));
            }
        }

        public void StopWork()
        {
            isWorking = false;
        }
    }
}
