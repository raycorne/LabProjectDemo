using LabProjectDemo.Infrastructure.Cameras;
using LabProjectDemo.Infrastructure.Interfaces;

namespace LabProjectDemo.Infrastructure.ProductionLines
{
    public class ProductionLineBuilder : IProductionLineBuilder
    {
        private ProductionLine _productionLine = new ProductionLine();

        public ProductionLine Build()
        {
            return _productionLine;
        }

        public IProductionLineBuilder SetBoxCamera(BoxCamera boxCamera)
        {
            _productionLine.boxCamera = boxCamera;
            return this;
        }

        public IProductionLineBuilder SetPalletCamera(PalletCamera palletCamera)
        {

            _productionLine.palletCamera = palletCamera;
            return this;
        }

        public IProductionLineBuilder SetProductCamera(ProductCamera productCamera)
        {
            _productionLine.productCamera = productCamera;
            return this;
        }
    }
}
