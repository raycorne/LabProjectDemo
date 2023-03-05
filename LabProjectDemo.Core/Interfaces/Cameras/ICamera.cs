namespace LabProjectDemo.Core.Interfaces.Cameras
{
    public interface ICamera
    {
        public void Connect();
        public void Disconnect();

        public string[] GetCodes();

        public void AddLinkedCodesToDb(string[] codes, string id);
        public void AddUnlinkedCodesToDb(string[] codes);

    }
}
