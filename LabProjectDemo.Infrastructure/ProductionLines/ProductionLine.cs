using LabProjectDemo.Infrastructure.Cameras;

namespace LabProjectDemo.Infrastructure.ProductionLines
{
    public class ProductionLine
    {
        public List<ProductCamera>? productCameras;
        public List<BoxCamera>? boxCameras;
        public List<PalletCamera>? palletCameras;
        //public Printer printer;

        private Thread _lineThread;

        public bool isWorking { get; private set; } = false;
        private int _requiredAmountOfProducts = 0;
        private int _requiredAmountOfBoxs = 0;

        public ProductionLine()
        {
            _lineThread = new Thread(StartLineThread);
        }

        public void StartWork()
        {
            _lineThread.Start();
        }

        private void StartLineThread()
        {
            try
            {
                isWorking = true;
                DeviceConnection();
                while (isWorking)
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

        private void DeviceConnection()
        {
            foreach (var camera in productCameras)
            {
                camera.Connect();
            }
            foreach (var camera in boxCameras)
            {
                camera.Connect();
            }
            foreach (var camera in boxCameras)
            {
                camera.Connect();
            }
        }



        public void StopWork()
        {
            _lineThread.Join();
        }
    }
}
