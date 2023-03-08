using LabProjectDemo.Infrastructure.Cameras;
using LabProjectDemo.Infrastructure.ProductionLines;

namespace LabProjectDemo.Infrastructure.Interfaces
{
    public interface IProductionLineBuilder
    {
        IProductionLineBuilder SetProductCamera(List<ProductCamera> productCamera);
        IProductionLineBuilder SetBoxCamera(List<BoxCamera> boxCamera);
        IProductionLineBuilder SetPalletCamera(List<PalletCamera> palletCamera);

        ProductionLine Build();
    }
}
