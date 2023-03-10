namespace LabProjectDemo.Core.Interfaces
{
    public interface IDeviceController
    {
        public void StartLine(int index);
        public void StopLine(int index);

        public bool isWorking(int index);
    }
}
