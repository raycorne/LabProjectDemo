using LabProjectDemo.Core;
using LabProjectDemo.Core.Interfaces.Cameras;
using LabProjectDemo.Core.Services.Camera;
using LabProjectDemo.Core.Services;
using LabProjectDemo.Infrastructure.Interfaces;
using LabProjectDemo.Infrastructure.NetworkConnector;
using LabProjectDemo.Infrastructure.Repositories;
using LabProjectDemo.Core.Entities;

namespace LabProjectDemo.UI
{
    public partial class MainForm : Form, IVeiwController
    {
        ICameraController cameraController;
        public MainForm()
        {
            cameraController = new CameraController(
                new CameraTCPConnector(), new CameraCodeDecoderService(),
                new MarkcodeService<ProductMarkcode>(new MarkcodeRepository<ProductMarkcode>()), this);
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
            if (cameraController.isWorking() == false)
            {
                cameraController.StartCameraThread();
                workButton.Text = "Stop";
            }
            else
            {
                workButton.Enabled = false;
                await Task.Run(() => cameraController.StopWork());
                workButton.Enabled = true;
                workButton.Text = "Start";
            }
        }

    }
}