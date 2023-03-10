using LabProjectDemo.Core.DTO;
using LabProjectDemo.Core.Interfaces.Markcodes;
using LabProjectDemo.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;

namespace LabProjectDemo.Infrastructure.Repositories
{
    public class MarkcodeRepository : IMarkcodeRepository
    {
        private AppDbContext _db;
        /*private DbContext _context;
        private DbSet<MarkcodeDbDTO> _dbSet;*/

        public void AddMarkcode(MarkcodeDTO markcode)
        {
            using (_db = new AppDbContext(DatabaseConfiguration.s_options))
            {
                var pallet = markcode;
                string palletId = Guid.NewGuid().ToString();
                _db.PalletMarkcodes.Add(new Core.Entities.PalletMarkcode
                {
                    Id = palletId,
                    Code = pallet.code
                });
                foreach(var boxes in pallet.markcodeDbDTOs)
                {
                    string boxId = Guid.NewGuid().ToString();
                    _db.BoxMarkcodes.Add(new Core.Entities.BoxMarkcode
                    {
                        Id = boxId,
                        Code = boxes.code,
                        PalletCodeId = boxId
                    });
                    foreach(var products in boxes.markcodeDbDTOs)
                    {
                        _db.ProductMarkcodes.Add(new Core.Entities.ProductMarkcode
                        {
                            Id = Guid.NewGuid().ToString(),
                            Code = products.code,
                            BoxCodeId = boxId
                        });
                    }
                }
                //_db.Markcode.Add(markcode);
                _db.SaveChanges();
            }
        }

        public void DeleteMarkcodeById(string id)
        {
            throw new NotImplementedException();
        }

        public List<MarkcodeDTO> GetAllMarkcodes()
        {
            throw new NotImplementedException();
        }

        public MarkcodeDTO GetMarkcode(string id)
        {
            throw new NotImplementedException();
        }
    }
}
