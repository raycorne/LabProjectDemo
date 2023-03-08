using LabProjectDemo.Core.Entities;
using LabProjectDemo.Core.Interfaces.Cameras;
using LabProjectDemo.Core.Interfaces.Markcodes;
using LabProjectDemo.Infrastructure.Interfaces;

namespace LabProjectDemo.Core
{
    public class CameraController : ICameraController
    {
        private readonly ICameraNetworkModule _cameraNetworkModule;     // CameraTCPConnector
        private readonly ICameraCodeDecoder _codeDecoder;               // CameraCodeDecoderService
        private readonly IMarkcodeService<ProductMarkcode> _markcodeService;             // MarkcodeService
        private readonly IVeiwController _viewController;               // Какой-то класс из view

        private Thread _thread;
        private Task _addToDbTask;
        private bool isWorkingStatus { get; set; } = false;

        public CameraController(ICameraNetworkModule cameraConnector, ICameraCodeDecoder codeDecoder,
            IMarkcodeService<ProductMarkcode> markcodeService, IVeiwController viewController)
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
            try
            {
                isWorkingStatus = true;
                _cameraNetworkModule.Connect();
                while (isWorkingStatus)
                {
                    string[] decodedCodes = _codeDecoder.Decode(_cameraNetworkModule.GetEncodedCode());
                    if (_codeDecoder.isCodesCorrected(decodedCodes))
                    {
                        _viewController.ShowReadedCode(decodedCodes[0]);
                        _viewController.UpdeteCounter();
                        _addToDbTask = Task.Run(() => AddCodes(decodedCodes.Take(decodedCodes.Length).ToArray()));
                        await _addToDbTask;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void AddCodes(string[] codes)
        {
            foreach (string code in codes)
            {
                _markcodeService.AddMarkcode(new Entities.ProductMarkcode { Id = Guid.NewGuid().ToString(), Code = code });
            }
        }

        public async void StopWork()
        {
            isWorkingStatus = false;
            await _addToDbTask;
            _thread.Join();
        }

        public bool isWorking()
        {
            return isWorkingStatus;
        }
    }
}
