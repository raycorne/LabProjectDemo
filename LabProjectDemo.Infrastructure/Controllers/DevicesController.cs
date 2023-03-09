using LabProjectDemo.Core.Interfaces;
using LabProjectDemo.Infrastructure.ProductionLines;

namespace LabProjectDemo.Infrastructure.Controllers
{
    public class DevicesController : IDeviceController
    {
        private List<ProductionLine> _lines;

        public DevicesController(List<ProductionLine> lines)
        {
            _lines = lines;
        }

        public void StartCamera(int index)
        {
            _lines[index].StartWork();
        }

        public void StopCamera(int index)
        {
            throw new NotImplementedException();
        }
    }
}
