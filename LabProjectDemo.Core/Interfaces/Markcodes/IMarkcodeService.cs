using LabProjectDemo.Core.DTO;

namespace LabProjectDemo.Core.Interfaces.Markcodes
{
    public interface IMarkcodeService
    {
        public void AddMarkcode(MarkcodeDTO markcode);
        public void DeleteMarkcodeById(string id);
        public MarkcodeDTO GetMarkcode(string id);
        public List<MarkcodeDTO> GetAllMarkcodes();
    }
}
