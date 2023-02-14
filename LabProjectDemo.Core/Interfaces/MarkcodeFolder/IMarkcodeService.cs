using LabProjectDemo.Core.Entities;

namespace LabProjectDemo.Core.Interfaces.MarkcodeFolder
{
    public interface IMarkcodeService
    {
        public void AddMarkcode(Markcode markcode);
        public void DeleteMarkcodeById(Guid id);
        public Markcode GetMarkcode(Guid id);
        public List<Markcode> GetAllMarkcodes();
    }
}
