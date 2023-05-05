using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Taigate.Mongo.Entities
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();

        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate);

        Task AddAsync(T obj);

        Task DeleteAsync(Expression<Func<T, bool>> predicate);
    }
}