namespace Catalog.Api.Repository
{
    public interface IRepository<T> where T : class
    {
        public Task<List<T>> GetListAsync();
        public Task<T> Add(T entity);
        public Task<T> Update(T entity);
        public void Delete(T entity);
    }
}
