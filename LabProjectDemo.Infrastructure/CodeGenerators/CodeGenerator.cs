using LabProjectDemo.Core.Interfaces;

namespace LabProjectDemo.Infrastructure.CodeGenerators
{
    public class CodeGenerator : IMarkcodeDevice
    {
        public string[] GetCodes()
        {
            return GenerateCode();
        }

        private string[] GenerateCode()
        {
            string[] code = { "<start>111111111111111111<stop>" };
            return code;
        }

        public void StartWork()
        {
            throw new NotImplementedException();
        }

        public void StopWork()
        {
            throw new NotImplementedException();
        }
    }
}
