using LabProjectDemo.Core.Interfaces;
using LabProjectDemo.Infrastructure.Interfaces;
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

        public void StartCamera(int index)
        {
            _lines[index].StartWork();
        }

        public void StopCamera(int index)
        {
            _lines[index].StopWork();
        }

        public bool isWorking(int index)
        {
            return _lines[index].isWorking;
        }
    }
}
