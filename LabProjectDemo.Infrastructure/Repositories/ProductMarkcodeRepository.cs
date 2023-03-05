using LabProjectDemo.Core.Entities;
using LabProjectDemo.Core.Interfaces.Markcodes;
using LabProjectDemo.Infrastructure.EFCore;

namespace LabProjectDemo.Infrastructure.Repositories
{
    public class ProductMarkcodeRepository : IMarkcodeRepository<ProductMarkcode>
    {
        private AppDbContext _db;
        public void AddMarkcode(ProductMarkcode markcode)
        {
            using (_db = new AppDbContext(DatabaseConfiguration.s_options))
            {
                _db.ProductMarkcodes.Add(markcode);
                _db.SaveChanges();
            }
        }

        public void DeleteMarkcodeById(string id)
        {
            throw new NotImplementedException();
        }

        public List<ProductMarkcode> GetAllMarkcodes()
        {
            throw new NotImplementedException();
        }

        public ProductMarkcode GetMarkcode(string id)
        {
            throw new NotImplementedException();
        }
    }
}
