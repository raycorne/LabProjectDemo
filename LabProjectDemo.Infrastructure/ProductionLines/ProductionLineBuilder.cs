using LabProjectDemo.Core.Interfaces;
using LabProjectDemo.Infrastructure.Interfaces;
using LabProjectDemo.Infrastructure.Interfaces.UIs;

namespace LabProjectDemo.Infrastructure.ProductionLines
{
    public class ProductionLineBuilder : IProductionLineBuilder
    {
        private ProductionLine _productionLine;

        public ProductionLineBuilder(ILineView lineView)
        {
            _productionLine = new ProductionLine(lineView);
        }

        public ProductionLine Build()
        {
            return _productionLine;
        }

        public IProductionLineBuilder SetBoxCamera(List<IMarkcodeDevice> boxCamera)
        {
            _productionLine.boxCameras = boxCamera;
            return this;
        }

        public IProductionLineBuilder SetPalletCamera(List<IMarkcodeDevice> palletCamera)
        {

            _productionLine.palletCameras = palletCamera;
            return this;
        }

        public IProductionLineBuilder SetProductCamera(List<IMarkcodeDevice> productCamera)
        {
            _productionLine.productCameras = productCamera;
            return this;
        }
    }
}
