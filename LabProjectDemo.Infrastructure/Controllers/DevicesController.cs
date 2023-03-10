using LabProjectDemo.Core.Interfaces;
using LabProjectDemo.Infrastructure.Interfaces.UIs;
using LabProjectDemo.Infrastructure.ProductionLines;

namespace LabProjectDemo.Infrastructure.Controllers
{
    public class DevicesController : IDeviceController
    {
        private ProductionLine _line;
        private readonly IMainView _mainView;

        public DevicesController(ProductionLine line, IMainView mainView)
        {
            _line = line;
            _mainView = mainView;
        }

        public void StartLine()
        {
            _line.StartWork();
        }

        public void StopLine()
        {
            _line.StopWork();
        }

        public bool isWorking()
        {
            return _line.isWorking;
        }
    }
}
