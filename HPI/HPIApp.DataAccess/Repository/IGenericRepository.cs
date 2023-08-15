using System.Linq.Expressions;

namespace HPIApp.DataAccess.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter, string? includeProperties = null, bool isTracked = false);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null, string? includeProperties = null, bool isTracked = false);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(List<TEntity> entity);
        Task Remove(TEntity entity);
    }
}
