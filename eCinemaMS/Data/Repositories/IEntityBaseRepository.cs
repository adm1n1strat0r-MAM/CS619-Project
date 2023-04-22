using eCinemaMS.Models;
using System.Linq.Expressions;

namespace eCinemaMS.Data.Repositories
{
    public interface IEntityBaseRepository <TEntity> where TEntity : class, IEntityBase, new()
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includeProperties);
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetByIdAsyns(int id, params Expression<Func<TEntity, object>>[] includeProperties);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(int Id, TEntity entity);
        Task DeleteAsync(int Id);
    }
}
