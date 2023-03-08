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

        public IProductionLineBuilder SetBoxCamera(List<BoxCamera> boxCamera)
        {
            _productionLine.boxCameras = boxCamera;
            return this;
        }

        public IProductionLineBuilder SetPalletCamera(List<PalletCamera> palletCamera)
        {

            _productionLine.palletCameras = palletCamera;
            return this;
        }

        public IProductionLineBuilder SetProductCamera(List<ProductCamera> productCamera)
        {
            _productionLine.productCameras = productCamera;
            return this;
        }
    }
}
