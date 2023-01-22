
using System.Linq.Expressions;

namespace Instagram_Clone_Backend.Data_Access
{
    public interface IEFentityRepository<T> where T : class, new()
    {
        public T? Get(Expression<Func<T,bool>> filter);
        public List<T> GetList(Expression<Func<T, bool>>? filter = null);
        public T Add(T entity);
        public T? Update(T entity);
        public T Delete(T entity);

    }

}
