using LabProjectDemo.Core.Interfaces;
using LabProjectDemo.Infrastructure.ProductionLines;

namespace LabProjectDemo.Infrastructure.Controllers
{
    public class DevicesController : IDeviceController
    {
        private List<ProductionLine> _lines;
        private List<Thread> _threads;

        public DevicesController(List<ProductionLine> lines)
        {
            _lines = lines;
            _threads = new List<Thread>();
            foreach(var line in _lines)
            {
                _threads.Add(new Thread(line.StartWork));
            }
        }

        public void StartCamera(int index)
        {

        }

        public void StopCamera(int index)
        {
            throw new NotImplementedException();
        }
    }
}
