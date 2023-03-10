using LabProjectDemo.Core.Interfaces;
using LabProjectDemo.Infrastructure.ProductionLines;

namespace LabProjectDemo.Infrastructure.Interfaces
{
    public interface IProductionLineBuilder
    {
        IProductionLineBuilder SetProductCamera(List<IMarkcodeDevice> productCamera);
        IProductionLineBuilder SetBoxCamera(List<IMarkcodeDevice> boxCamera);
        IProductionLineBuilder SetPalletCamera(List<IMarkcodeDevice> palletCamera);

        ProductionLine Build();
    }
}
