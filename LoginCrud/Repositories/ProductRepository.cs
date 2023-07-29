using LoginCrud.Common;
using LoginCrud.Contracts;
using LoginCrud.Data;

namespace LoginCrud.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
        }

        public async Task<PaginatedResult<Product>> GetPaginated(int page, int pageSize, string keyword)
        {
            return await GetPaginated(page, pageSize, t => t.Name.Contains(keyword ?? string.Empty));
        }
    }
}
