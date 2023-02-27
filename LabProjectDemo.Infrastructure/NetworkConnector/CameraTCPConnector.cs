using LabProjectDemo.Core.Interfaces.Camera;
using Microsoft.Extensions.Configuration;
using System.Net.Sockets;
using System.Text;

namespace LabProjectDemo.Infrastructure.NetworkConnector
{
    public class CameraTCPConnector : ICameraNetworkModule
    {
        private string? _ip = null;
        private int _port = 0;
        private TcpClient _tcpClient = null;
        private NetworkStream _stream;

        public void Connect()
        {
            try
            {
                GetConnectionDataFromJson();
                _tcpClient = new TcpClient(_ip, _port);
                //_tcpClient.Connect(ip, port);
                _stream = _tcpClient.GetStream();
            }
            catch (Exception ex)
            {

            }
        }

        private void GetConnectionDataFromJson()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("devicesConfig.json")
                .Build();
            _ip = configuration["MainCamera:ip"];
            _port = Int32.Parse(configuration["MainCamera:port"]);
        }

        public void Disconnect()
        {
            if (_stream != null)
            {
                _stream.Close();
                _stream = null;
            }
            if(_tcpClient != null)
            {
                _tcpClient.Close();
                _tcpClient = null;
            }
        }

        public void CheckConnectionStatus()
        {
            throw new NotImplementedException();
        }

        public string GetEncodedCode()
        {
            byte[] data = new byte[128];
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = _stream.Read(data, 0, data.Length);
                builder.Append(Encoding.ASCII.GetString(data, 0, bytes));

            } while (_stream.DataAvailable);
            return builder.ToString();
        }
    }
}
