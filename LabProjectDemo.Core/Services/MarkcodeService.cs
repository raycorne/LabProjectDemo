using LabProjectDemo.Core.Interfaces.Markcodes;

namespace LabProjectDemo.Core.Services
{
    public class MarkcodeService<TEntity> : IMarkcodeService<TEntity> where TEntity : class
    {
        public readonly IMarkcodeRepository<TEntity> _markcodeRepository;

        public MarkcodeService(IMarkcodeRepository<TEntity> markcodeRepository)
        {
            _markcodeRepository = markcodeRepository;
        }

        public void AddMarkcode(TEntity markcode)
        {
            _markcodeRepository.AddMarkcode(markcode);
        }

        public void DeleteMarkcodeById(string id)
        {
            _markcodeRepository.DeleteMarkcodeById(id);
        }

        public List<TEntity> GetAllMarkcodes()
        {
            return _markcodeRepository.GetAllMarkcodes();
        }

        public TEntity GetMarkcode(string id)
        {
            return _markcodeRepository.GetMarkcode(id);
        }
    }
}
