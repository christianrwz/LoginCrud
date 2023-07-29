using LoginCrud.Common;
using LoginCrud.Contracts;
using LoginCrud.Data;
using Microsoft.EntityFrameworkCore;

namespace LoginCrud.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbContext _db;
        private readonly DbSet<T> _table;

        public BaseRepository(ApplicationDbContext db)
        {
            _db = db;
            _table = db.Set<T>();

        }
        public async Task Create(T t)
        {
            await _table.AddAsync(t);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(object id)
        {
            var t = await GetOne(id);
            if (t != null) { 
                _table.Remove(t); 
                await _db.SaveChangesAsync(); 
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> GetOne(object id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<PaginatedResult<T>> GetPaginated(int page, int pageSize)
        {
            var count = await _table.CountAsync();
            var records = await _table
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return new PaginatedResult<T>
            {
                Result = records,
                Page = page,
                TotalCount = (int)Math.Ceiling(count / (double)pageSize)
            };
        }

        public async Task Update(object id, object model)
        {
            var t = await GetOne(id);
            if (t != null) {
                _db.Entry(t).CurrentValues.SetValues(model);
                await _db.SaveChangesAsync();
            }
        }
    }
}
