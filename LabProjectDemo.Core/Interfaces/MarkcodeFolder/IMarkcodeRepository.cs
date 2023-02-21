using LabProjectDemo.Core.Entities;

namespace LabProjectDemo.Core.Interfaces.MarkcodeFolder
{
    public interface IMarkcodeRepository
    {
        public void AddMarkcode(Markcode markcode);
        public void DeleteMarkcodeById(string id);
        public Markcode GetMarkcode(string id);
        public List<Markcode> GetAllMarkcodes();
    }
}
