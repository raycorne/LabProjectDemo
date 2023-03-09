using LabProjectDemo.Core;
using LabProjectDemo.Core.Interfaces.Cameras;
using LabProjectDemo.Core.Services.Camera;
using LabProjectDemo.Core.Services;
using LabProjectDemo.Infrastructure.Interfaces;
using LabProjectDemo.Infrastructure.NetworkConnector;
using LabProjectDemo.Infrastructure.Repositories;
using LabProjectDemo.Core.Entities;
using LabProjectDemo.Core.Interfaces;
using LabProjectDemo.Infrastructure.Controllers;

namespace LabProjectDemo.UI
{
    public partial class MainForm : Form, IMainView
    {
        ICameraController cameraController;
        private readonly IDeviceController _deviceController;
        public MainForm()
        {
            LabProjectDemo.Infrastructure.Startup startup = new();
            _deviceController = new DevicesController(
                startup.GetConfiguretedProductionLines(), this);

            /*cameraController = new CameraController(
                new CameraTCPConnector(), new CameraCodeDecoderService(),
                new MarkcodeService<ProductMarkcode>(new MarkcodeRepository<ProductMarkcode>()), this);*/
            InitializeComponent();
        }

        public void ShowReadedCode(string code)
        {
            this.Invoke(new Action(() => readedCodes.Text = code));
        }

        public void UpdeteCounter()
        {
            this.Invoke(new Action(() =>
            {
                int number = Int32.Parse(numOfReaded.Text);
                number++;
                numOfReaded.Text = number.ToString();
            }));
            
        }

        async private void workButton_Click(object sender, EventArgs e)
        {
            if (_deviceController.isWorking(1))
            {
                _deviceController.StartCamera(1);
                workButton.Text = "Stop";
            }
            else
            {
                workButton.Enabled = false;
                await Task.Run(() => _deviceController.StopCamera(1));
                workButton.Enabled = true;
                workButton.Text = "Start";
            }
        }

    }
}