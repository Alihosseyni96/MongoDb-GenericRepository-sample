using MongoDb_Sample.Models;
using System.Linq.Expressions;

namespace MongoDb_Sample.Repositories.BaseRepository
{
    public interface IBaseRepository<T> where T :class
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetByCondition(Expression<Func<T, bool>> expression);
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(Expression<Func<T, bool>> expression, T entity);
        Task DeleteAsync(Expression<Func<T, bool>> expression);

    }
}
