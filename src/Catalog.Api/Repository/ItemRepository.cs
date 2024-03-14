using Catalog.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Api.Repository
{
    public class ItemRepository : IRepository<Item>
    {
        protected readonly DbContext _context;

        protected DbSet<Item> _dbSet;

        public ItemRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<Item>();
        }
        public async Task<Item> Add(Item entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public void Delete(Item entity)
        {
            _dbSet.Remove(entity);
        }

        public Task<List<Item>> GetListAsync()
        {
            return _dbSet.ToListAsync();
        }

        public async Task<Item> Update(Item entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
