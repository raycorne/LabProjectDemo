namespace LabProjectDemo.Core.Interfaces.Cameras
{
    public interface ICameraController
    {
        public void StartCameraThread();
        public void StopWork();
        public bool isWorking();
    }
}
