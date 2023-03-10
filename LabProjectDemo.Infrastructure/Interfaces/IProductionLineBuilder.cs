using LabProjectDemo.Infrastructure.Cameras;
using LabProjectDemo.Infrastructure.ProductionLines;

namespace LabProjectDemo.Infrastructure.Interfaces
{
    public interface IProductionLineBuilder
    {
        IProductionLineBuilder SetProductCamera(List<Camera> productCamera);
        IProductionLineBuilder SetBoxCamera(List<Camera> boxCamera);
        IProductionLineBuilder SetPalletCamera(List<Camera> palletCamera);

        ProductionLine Build();
    }
}
