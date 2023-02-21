namespace LabProjectDemo.Core.Interfaces.Camera
{
    public interface ICameraCodeDecoder
    {
        public string[] Decode(string undecodedCodes);
        public bool isCodesCorrected(string[] codes);
    }
}
