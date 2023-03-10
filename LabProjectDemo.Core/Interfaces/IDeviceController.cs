namespace LabProjectDemo.Core.Interfaces
{
    public interface IDeviceController
    {
        public void StartLine();
        public void StopLine();

        public bool isWorking();
    }
}
