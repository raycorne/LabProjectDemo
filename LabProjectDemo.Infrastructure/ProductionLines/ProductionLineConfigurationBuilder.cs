using LabProjectDemo.Core.Interfaces;
using LabProjectDemo.Core.Services.Camera;
using LabProjectDemo.Infrastructure.Cameras;
using LabProjectDemo.Infrastructure.CodeGenerators;
using LabProjectDemo.Infrastructure.Interfaces;
using LabProjectDemo.Infrastructure.Interfaces.UIs;
using LabProjectDemo.Infrastructure.NetworkConnector;
using LabProjectDemo.Infrastructure.ProductionLines.DTO;

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

        public ProductionLineConfigurationBuilder(LineJsonDTO line, ILineView lineView)
        {
            _line = line;
            _productionLineBuilder = new ProductionLineBuilder(lineView);
        }

        public ProductionLine GetBuildedProductionLine()
        {
            SetDeviceAvailabilityStatus();
            ConfigurateAllDevices();
            return _productionLineBuilder.Build();
        }

        private void SetDeviceAvailabilityStatus()
        {
            if (_line.productCamera != null)
                isProductCamerasAvailable = true;
            if (_line.boxCamera != null)
                isBoxCamerasAvailable = true;
            if (_line.palletCamera != null)
                isPalletCamerasAvailable = true;
        }

        private void ConfigurateAllDevices()
        {
            _productionLineBuilder.SetProductCamera(ConfigurateCameraOrCodeDecoder(_line.productCamera))
                .SetBoxCamera(ConfigurateCameraOrCodeDecoder(_line.boxCamera))
                .SetPalletCamera(ConfigurateCameraOrCodeDecoder(_line.palletCamera));

            /*if (_line.printer != null)
            {
                isPrinterAvailable = true;
                _productionLineBuilder.SetPrinter(new Printer());
            }*/
        }

        private List<IMarkcodeDevice> ConfigurateCameraOrCodeDecoder(List<CameraJsonDTO> cameras)
        {
            List<IMarkcodeDevice> buildedCameras = new();
            if(cameras != null)
            {
                foreach (CameraJsonDTO camera in cameras)
                {
                    buildedCameras.Add(new Camera(
                        new CameraTCPConnector(camera.ip, camera.port),
                        new CameraCodeDecoderService()));
                }
            } else
            {
                buildedCameras.Add(new CodeGenerator());
            }
            return buildedCameras;
        }
    }
}
