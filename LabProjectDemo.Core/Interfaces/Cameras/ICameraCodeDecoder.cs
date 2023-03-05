namespace LabProjectDemo.Core.Interfaces.Cameras
{
    public interface ICameraCodeDecoder
    {
        public string[] Decode(string undecodedCodes);
        public bool isCodesCorrected(string[] codes);
    }
}
