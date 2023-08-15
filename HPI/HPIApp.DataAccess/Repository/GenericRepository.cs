using HPIApp.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HPIApp.DataAccess.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDBContext _db;
        internal DbSet<TEntity> dbSet;
        public GenericRepository(ApplicationDBContext db)
        {
            _db = db;
            dbSet = _db.Set<TEntity>();
        }
        public async Task AddAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(List<TEntity> entity)
        {
            await dbSet.AddRangeAsync(entity);
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null, string? includeProperties = null, bool isTracked = false)
        {
            IQueryable<TEntity> query = dbSet;

            if (isTracked)
                query = dbSet;
            else
                query = dbSet.AsNoTracking();

            if (includeProperties is not null)
                query = IncludeProperties(includeProperties);

            if (filter is not null)
                query = query.Where(filter);

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter, string? includeProperties = null, bool isTracked = false)
        {
            IQueryable<TEntity> query;

            if (isTracked)
                query = dbSet;
            else
                query = dbSet.AsNoTracking();

            if (includeProperties is not null)
                query = IncludeProperties(includeProperties);

            query = query.Where(filter);
            return await query.FirstOrDefaultAsync();
        }

        public async Task Remove(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        private IQueryable<TEntity> IncludeProperties(string? includeProperties)
        {
            IQueryable<TEntity> query = dbSet;

            foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProp);

            return query;
        }
    }
}
