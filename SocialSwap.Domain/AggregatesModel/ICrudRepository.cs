namespace SocialSwap.Domain.AggregatesModel
{
    public interface ICrudRepository<T> where T : class
    {
        public abstract IEnumerable<T> Index();
        public abstract T Get(int id);
        public abstract T Create(T entity);
        public abstract T Update(T entity);
        public abstract T Delete(T entity);
    }
}
