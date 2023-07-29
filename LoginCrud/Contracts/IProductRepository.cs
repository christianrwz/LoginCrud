using LoginCrud.Common;
using LoginCrud.Data;

namespace LoginCrud.Contracts
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<PaginatedResult<Product>> GetPaginated(int page, int pageSize, string keyword);
    }
}
