using LabProjectDemo.Core.Entities;

namespace LabProjectDemo.Core.Interfaces.MarkcodeFolder
{
    public interface IMarkcodeService<TEntity> where TEntity : class
    {
        public void AddMarkcode(TEntity markcode);
        public void DeleteMarkcodeById(string  id);
        public TEntity GetMarkcode(string id);
        public List<TEntity> GetAllMarkcodes();
    }
}
