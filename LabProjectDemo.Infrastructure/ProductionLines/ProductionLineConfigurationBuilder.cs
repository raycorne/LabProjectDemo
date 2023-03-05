using LabProjectDemo.Infrastructure.Cameras;
using LabProjectDemo.Infrastructure.Interfaces;
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

        public void Configurate()
        {
            if (_line.productCamera != null)
            {
                isProductCamerasAvailable = true;
                _productionLineBuilder.SetProductCamera(new ProductCamera());
            }
            if (_line.boxCamera != null)
            {
                isBoxCamerasAvailable = true;
                _productionLineBuilder.SetBoxCamera(new BoxCamera());
            }
            if (_line.palletCamera != null)
            {
                isPalletCamerasAvailable = true;
                _productionLineBuilder.SetPalletCamera(new PalletCamera());
            }
            /*if (_line.printer != null)
            {
                isPrinterAvailable = true;
                _productionLineBuilder.SetPrinter(new Printer());
            }*/
        }
    }
}
