namespace LabProjectDemo.Core.Interfaces.Camera
{
    public interface ICameraController
    {
        public void StartCameraThread();
        public void StopWork();
        public bool isWorking();
    }
}
