using LabProjectDemo.Core.Entities;

namespace LabProjectDemo.Core.Interfaces.MarkcodeFolder
{
    public interface IMarkcodeRepository
    {
        public void AddMarkcode(Markcode markcode);
        public void DeleteMarkcodeById(Guid id);
        public Markcode GetMarkcode(Guid id);
        public List<Markcode> GetAllMarkcodes();
    }
}
