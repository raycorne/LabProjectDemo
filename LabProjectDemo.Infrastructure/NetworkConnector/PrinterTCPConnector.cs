using LabProjectDemo.Core.Interfaces.PrinterInterfaces;

namespace LabProjectDemo.Core.Services.Printer
{
    public class PrinterTCPConnector : IPrinterNetworkModule
    {
        public void Connect(string ip, int port)
        {
            throw new NotImplementedException();
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }
        public void CheckConnectionStatus()
        {
            throw new NotImplementedException();
        }
    }
}
