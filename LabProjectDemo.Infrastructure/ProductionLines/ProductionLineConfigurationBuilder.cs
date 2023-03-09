using LabProjectDemo.Core.Entities;
using LabProjectDemo.Core.Services;
using LabProjectDemo.Core.Services.Camera;
using LabProjectDemo.Infrastructure.Cameras;
using LabProjectDemo.Infrastructure.Interfaces;
using LabProjectDemo.Infrastructure.NetworkConnector;
using LabProjectDemo.Infrastructure.ProductionLines.DTO;
using LabProjectDemo.Infrastructure.Repositories;

namespace LabProjectDemo.Infrastructure.ProductionLines
{
    public class ProductionLineConfigurationBuilder
    {
        private IProductionLineBuilder _productionLineBuilder;
        public bool isProductCamerasAvailable { get; private set; } = false;
        public bool isBoxCamerasAvailable { get; private set; } = false;
        public bool isPalletCamerasAvailable { get; private set; } = false;
        public bool isPrinterAvailable { get; private set; } = false;

        private LineJsonDTO _line;
        private IVeiwController _veiwController;
        public ProductionLineConfigurationBuilder(LineJsonDTO line)
        {
            _line = line;
            _productionLineBuilder = new ProductionLineBuilder();
        }

        public ProductionLine GetBuildedProductionLine()
        {
            Configurate();
            return _productionLineBuilder.Build();
        }

        private void Configurate()
        {
            if (_line.productCamera != null)
            {
                isProductCamerasAvailable = true;
                List<ProductCamera> productCameras = new List<ProductCamera>();
                foreach(CameraJsonDTO productCamera in _line.productCamera)
                {
                    productCameras.Add(new ProductCamera(
                        new CameraTCPConnector(productCamera.ip, productCamera.port),
                        new CameraCodeDecoderService(),
                        new MarkcodeService<ProductMarkcode>(new MarkcodeRepository<ProductMarkcode>()),
                        _veiwController));
                }
                _productionLineBuilder.SetProductCamera(productCameras);
            }
            if (_line.boxCamera != null)
            {
                isBoxCamerasAvailable = true;
                List<BoxCamera> boxCameras = new List<BoxCamera>();
                foreach(CameraJsonDTO boxCamera in _line.boxCamera)
                {
                    boxCameras.Add(new BoxCamera(
                        new CameraTCPConnector(boxCamera.ip, boxCamera.port),
                        new CameraCodeDecoderService(),
                        new MarkcodeService<BoxMarkcode>(new MarkcodeRepository<BoxMarkcode>()),
                        _veiwController));
                }
                _productionLineBuilder.SetBoxCamera(boxCameras);
            }
            if (_line.palletCamera != null)
            {
                isPalletCamerasAvailable = true;
                List<PalletCamera> palletCameras = new List<PalletCamera>();
                foreach(CameraJsonDTO palletCamera in _line.palletCamera)
                {
                    palletCameras.Add(new PalletCamera(
                        new CameraTCPConnector(palletCamera.ip, palletCamera.port),
                        new CameraCodeDecoderService(),
                        new MarkcodeService<PalletMarkcode>(new MarkcodeRepository<PalletMarkcode>()),
                        _veiwController));
                }
                _productionLineBuilder.SetPalletCamera(palletCameras);
            }
            /*if (_line.printer != null)
            {
                isPrinterAvailable = true;
                _productionLineBuilder.SetPrinter(new Printer());
            }*/
        }
    }
}
