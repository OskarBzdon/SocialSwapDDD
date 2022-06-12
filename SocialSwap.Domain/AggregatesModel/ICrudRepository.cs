namespace SocialSwap.Domain.AggregatesModel
{
    public interface ICrudRepository<T> where T : class
    {
        public Task<IEnumerable<T>> Index();
        public Task<T> Get(int id);
        public Task<T> Create(T entity);
        public Task<T> Update(T entity);
        public Task<T> Delete(T entity);
    }
}
