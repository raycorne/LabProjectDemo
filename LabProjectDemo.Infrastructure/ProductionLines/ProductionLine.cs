using LabProjectDemo.Core.DTO;
using LabProjectDemo.Core.Interfaces;
using LabProjectDemo.Core.Interfaces.Markcodes;
using LabProjectDemo.Core.Services;
using LabProjectDemo.Infrastructure.Interfaces.UIs;
using LabProjectDemo.Infrastructure.Repositories;

namespace LabProjectDemo.Infrastructure.ProductionLines
{
    public class ProductionLine
    {
        public List<IMarkcodeDevice>? productCameras;
        public List<IMarkcodeDevice>? boxCameras;
        public List<IMarkcodeDevice>? palletCameras;
        //public Printer printer;

        private readonly IMarkcodeService _markcodeService;
        private readonly ILineView _lineView;

        private Thread _lineThread;
        private Task _addToDbTask;

        public bool isWorking { get; private set; } = false;
        private int _requiredAmountOfProducts = 16;
        private int _requiredAmountOfBoxs = 10;

        public ProductionLine(ILineView lineView)
        {
            _lineView = lineView;
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
                StartDevices();

                MarkcodeDTO pallet = new();

                while (isWorking)
                {
                    pallet = GetOnePallet();
                    _addToDbTask = Task.Run(() => { _markcodeService.AddMarkcode(pallet); });
                    await _addToDbTask;
                    _lineView.UpdeteCounter();
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

        private void StartDevices()
        {
            foreach (var camera in productCameras)
            {
                camera.StartWork();
            }
            foreach (var camera in boxCameras)
            {
                camera.StartWork();
            }
            foreach (var camera in palletCameras)
            {
                camera.StartWork();
            }
        }

        private MarkcodeDTO GetOnePallet()
        {
            List<MarkcodeDTO> boxes = new();
            List<MarkcodeDTO> products = new();
            string boxCode;
            string palletCode;
            while (boxes.Count < _requiredAmountOfBoxs)
            {
                while (products.Count < _requiredAmountOfProducts)
                {
                    foreach (var product in productCameras[0].GetCodes())
                    {
                        products.Add(new MarkcodeDTO { code = product, markcodeDTOs = null });
                    }
                }
                boxCode = boxCameras[0].GetCodes()[0];
                boxes.Add(new MarkcodeDTO { code = boxCode, markcodeDTOs = products });
            }
            palletCode = palletCameras[0].GetCodes()[0];
            return new MarkcodeDTO { code = palletCode, markcodeDTOs = boxes };
        }

        async public void StopWork()
        {
            isWorking = false;
            await _addToDbTask;
            _lineThread.Join();
        }
    }
}
