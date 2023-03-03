using LabProjectDemo.Core.Interfaces.MarkcodeFolder;
using LabProjectDemo.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;

namespace LabProjectDemo.Infrastructure.Repositories
{
    public class MarkcodeRepository<TEntity> : IMarkcodeRepository<TEntity> where TEntity : class
    {
        private AppDbContext _db;
        private DbContext _context;
        private DbSet<TEntity> _dbSet;

        /*public MarkcodeRepository(DbContext context)
        {
            _context = context;
            //_dbSet = context.Set<TEntity>();
            _db.Set<TEntity>();
        }*/
        public void AddMarkcode(TEntity markcode)
        {
            using (_db = new AppDbContext(DatabaseConfiguration.s_options))
            {
                var _dbSet = _db.Set<TEntity>();
                _dbSet.Add(markcode);
                //_db.Markcode.Add(markcode);
                _db.SaveChanges();
            }
        }

        public void DeleteMarkcodeById(string id)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAllMarkcodes()
        {
            throw new NotImplementedException();
        }

        public TEntity GetMarkcode(string id)
        {
            throw new NotImplementedException();
        }
    }
}
