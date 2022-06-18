namespace SocialSwap.Domain.AggregatesModel
{
    public interface ICrudRepository<T> where T : class
    {
        public IEnumerable<T> Index(string? selfId = null);
        public T Get(string id);
        public T Create(T entity);
        public T Update(T entity);
        public T Delete(T entity);
    }
}
