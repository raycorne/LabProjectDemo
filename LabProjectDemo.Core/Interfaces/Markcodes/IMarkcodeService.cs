using LabProjectDemo.Core.DTO;

namespace LabProjectDemo.Core.Interfaces.Markcodes
{
    public interface IMarkcodeService
    {
        public void AddMarkcode(MarkcodeDbDTO markcode);
        public void DeleteMarkcodeById(string id);
        public MarkcodeDbDTO GetMarkcode(string id);
        public List<MarkcodeDbDTO> GetAllMarkcodes();
    }
}
