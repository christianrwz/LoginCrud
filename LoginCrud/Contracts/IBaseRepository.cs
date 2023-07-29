using LoginCrud.Common;

namespace LoginCrud.Contracts
{
    public interface IBaseRepository<T>
    {
        Task Create(T t);
        Task<T> GetOne(object id);
        Task<IEnumerable<T>> GetAll();
        Task<PaginatedResult<T>> GetPaginated(int page, int pageSize);
        Task Update(object id, object model);
        Task Delete(object id);
    }
}
