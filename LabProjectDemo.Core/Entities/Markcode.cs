namespace LabProjectDemo.Core.Entities
{
    public class Markcode
    {
        private Guid _id;
        private string _code;
        public Markcode(Guid id, string code)
        {
            _id = id;
            _code = code;
        }
    }
}
