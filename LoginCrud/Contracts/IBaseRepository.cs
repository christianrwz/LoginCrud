namespace LoginCrud.Contracts
{
    public interface IBaseRepository<T>
    {
        Task Create(T t);
        Task<T> GetOne(object id);
        Task<IEnumerable<T>> GetAll();
        Task Update(object id, object model);
        Task Delete(object id);
    }
}
