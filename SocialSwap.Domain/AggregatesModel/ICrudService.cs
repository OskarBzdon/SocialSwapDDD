using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialSwap.Domain.AggregatesModel
{
    public interface ICrudService<T> where T : class
    {
        public Task<T> Create(T entity);

        public Task<T> Delete(T entity);

        public Task<T> Get(int id);

        public Task<IEnumerable<T>> Index();

        public Task<T> Update(T entity);
    }
}
