using LabProjectDemo.Core.Entities;
using LabProjectDemo.Core.Interfaces.MarkcodeFolder;
using LabProjectDemo.Infrastructure.EFCore;

namespace LabProjectDemo.Infrastructure.Repositories
{
    public class MarkcodeRepository : IMarkcodeRepository
    {
        private AppDbContext _db;
        public void AddMarkcode(Markcode markcode)
        {
            using (_db = new AppDbContext(DatabaseConfiguration.s_options))
            {
                _db.Markcode.Add(markcode);
                _db.SaveChanges();
            }
        }

        public void DeleteMarkcodeById(string id)
        {
            throw new NotImplementedException();
        }

        public List<Markcode> GetAllMarkcodes()
        {
            throw new NotImplementedException();
        }

        public Markcode GetMarkcode(string id)
        {
            throw new NotImplementedException();
        }
    }
}
