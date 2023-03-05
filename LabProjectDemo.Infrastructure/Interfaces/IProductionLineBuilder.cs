using LabProjectDemo.Infrastructure.Cameras;
using LabProjectDemo.Infrastructure.ProductionLines;

namespace LabProjectDemo.Infrastructure.Interfaces
{
    public interface IProductionLineBuilder
    {
        IProductionLineBuilder SetProductCamera(ProductCamera productCamera);
        IProductionLineBuilder SetBoxCamera(BoxCamera boxCamera);
        IProductionLineBuilder SetPalletCamera(PalletCamera palletCamera);

        ProductionLine Build();
    }
}
