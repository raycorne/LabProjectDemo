using LabProjectDemo.Core.DTO;
using LabProjectDemo.Core.Entities;
using LabProjectDemo.Core.Interfaces.Markcodes;
using LabProjectDemo.Core.Services;
using LabProjectDemo.Infrastructure.Cameras;
using LabProjectDemo.Infrastructure.Repositories;

namespace LabProjectDemo.Infrastructure.ProductionLines
{
    public class ProductionLine
    {
        public List<ProductCamera>? productCameras;
        public List<BoxCamera>? boxCameras;
        public List<PalletCamera>? palletCameras;
        //public Printer printer;

        private readonly IMarkcodeService _markcodeService;

        private Thread _lineThread;
        private Task _addToDbTask;

        public bool isWorking { get; private set; } = false;
        private int _requiredAmountOfProducts = 0;
        private int _requiredAmountOfBoxs = 0;

        public ProductionLine()
        {
            _lineThread = new Thread(StartLineThread);
            _markcodeService = new MarkcodeService(new MarkcodeRepository());

        }

        public void StartWork()
        {
            _lineThread.Start();
        }

        private async void StartLineThread()
        {
            try
            {
                isWorking = true;
                DeviceConnection();

                MarkcodeDbDTO pallets = new();
                List<MarkcodeDbDTO> boxes = new();
                List<MarkcodeDbDTO> products = new() ;
                string[] productCode = new string[] { };
                string boxCode;
                string palletCode;

                while (isWorking)
                {
                    while (productCode.Length != _requiredAmountOfProducts)
                    {
                        productCode = productCameras[0].GetCode();
                    }
                    foreach (var product in productCode)
                    {
                        products.Add(new MarkcodeDbDTO { code = product, markcodeDbDTOs = null });
                    }
                    boxCode = boxCameras[0].GetCode()[0];
                    boxes.Add(new MarkcodeDbDTO { code = boxCode, markcodeDbDTOs = products });
                    palletCode = palletCameras[0].GetCode()[0];
                    pallets = new MarkcodeDbDTO { code = palletCode, markcodeDbDTOs = boxes };
                    _addToDbTask = Task.Run(() =>
                    {
                        _markcodeService.AddMarkcode(pallets);
                    });
                    

                    /*                    string[] decodedCodes = _codeDecoder.Decode(_cameraNetworkModule.GetEncodedCode());
                                        if (_codeDecoder.isCodesCorrected(decodedCodes))
                                        {
                                            _viewController.ShowReadedCode(decodedCodes[0]);
                                            _viewController.UpdeteCounter();
                                            _addToDbTask = Task.Run(() => AddCodes(decodedCodes.Take(decodedCodes.Length).ToArray()));
                                            await _addToDbTask;
                                        }*/
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
            foreach (var camera in palletCameras)
            {
                camera.Connect();
            }
        }

        async public void StopWork()
        {
            await _addToDbTask;
            _lineThread.Join();
        }
    }
}
