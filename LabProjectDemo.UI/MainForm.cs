using LabProjectDemo.Core.Interfaces;
using LabProjectDemo.Core.Interfaces.Cameras;
using LabProjectDemo.Infrastructure.Controllers;
using LabProjectDemo.Infrastructure.Interfaces.UIs;

namespace LabProjectDemo.UI
{
    public partial class MainForm : Form, IMainView, ILineView
    {
        ICameraController cameraController;
        private readonly IDeviceController _deviceController;
        public MainForm()
        {
            LabProjectDemo.Infrastructure.Startup startup = new(this);
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
            if (_deviceController.isWorking(0) != true)
            {
                _deviceController.StartLine(0);
                workButton.Text = "Stop";
            }
            else
            {
                workButton.Enabled = false;
                await Task.Run(() => _deviceController.StopLine(0));
                workButton.Enabled = true;
                workButton.Text = "Start";
            }
        }

    }
}