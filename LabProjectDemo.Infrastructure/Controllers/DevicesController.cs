using LabProjectDemo.Core.Interfaces;
using LabProjectDemo.Infrastructure.Interfaces.UIs;
using LabProjectDemo.Infrastructure.ProductionLines;

namespace LabProjectDemo.Infrastructure.Controllers
{
    public class DevicesController : IDeviceController
    {
        private List<ProductionLine> _lines;
        private readonly IMainView _mainView;

        public DevicesController(List<ProductionLine> lines, IMainView mainView)
        {
            _lines = lines;
            _mainView = mainView;
        }

        public void StartLine(int index)
        {
            _lines[index].StartWork();
        }

        public void StopLine(int index)
        {
            _lines[index].StopWork();
        }

        public bool isWorking(int index)
        {
            return _lines[index].isWorking;
        }
    }
}
