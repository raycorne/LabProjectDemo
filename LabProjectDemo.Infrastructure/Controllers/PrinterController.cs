using LabProjectDemo.Core.Interfaces.Printers;

namespace LabProjectDemo.Infrastructure.Controllers
{
    public class PrinterController : IPrinterController
    {
        private readonly IPrinterNetworkModule _printerNetworkModule;

        public PrinterController(IPrinterNetworkModule printerNetworkModule)
        {
            _printerNetworkModule = printerNetworkModule;
        }

        public void CheckConnectionStatus()
        {
            throw new NotImplementedException();
        }

        public void PrintMarkcode()
        {
            throw new NotImplementedException();
        }
    }
}
