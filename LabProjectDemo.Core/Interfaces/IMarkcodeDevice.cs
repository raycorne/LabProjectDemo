namespace LabProjectDemo.Core.Interfaces
{
    public interface IMarkcodeDevice
    {
        public void StartWork();
        public void StopWork();
        public string[] GetCodes();
    }
}
