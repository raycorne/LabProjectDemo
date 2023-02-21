using LabProjectDemo.Core.Entities;
using LabProjectDemo.Core.Interfaces.MarkcodeFolder;

namespace LabProjectDemo.Core.Services
{
    public class MarkcodeService : IMarkcodeService
    {
        public readonly IMarkcodeRepository _markcodeRepository;

        public MarkcodeService(IMarkcodeRepository markcodeRepository)
        { 
            _markcodeRepository = markcodeRepository;
        }

        public void AddMarkcode(Markcode markcode)
        {
            _markcodeRepository.AddMarkcode(markcode);
        }

        public void DeleteMarkcodeById(string id)
        {
            _markcodeRepository.DeleteMarkcodeById(id);
        }

        public List<Markcode> GetAllMarkcodes()
        {
            return _markcodeRepository.GetAllMarkcodes();
        }

        public Markcode GetMarkcode(string id)
        {
            return _markcodeRepository.GetMarkcode(id);   
        }
    }
}
