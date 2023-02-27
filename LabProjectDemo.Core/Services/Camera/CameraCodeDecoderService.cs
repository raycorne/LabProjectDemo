using LabProjectDemo.Core.Interfaces.Camera;
using static System.Net.Mime.MediaTypeNames;

namespace LabProjectDemo.Core.Services.Camera
{
    public class CameraCodeDecoderService : ICameraCodeDecoder
    {

        public string[] Decode(string undecodedCodes)
        {
            //Поместить логику декода
            string[] codes = TrimCodes(undecodedCodes);
            return codes;
        }
        public bool isCodesCorrected(string[] codes)
        {
            foreach (string code in codes)
                if (code == "fail")
                    return false;
            return true;
        }

        public string[] TrimCodes(string message)
        {
            message = message.Substring(0, message.Length - 2);
            string[] codes;
            if (message.Contains("<start>") && message.EndsWith("<stop>"))
            {
                message = message.TrimStart("<start>".ToCharArray());
                message = message.TrimEnd("<stop>".ToCharArray());
                string split = "<next>";
                codes = message.Split(split);
            }
            else
            {
                codes = new string[] { "fail" };
            }
            return codes;
        }
    }
}
