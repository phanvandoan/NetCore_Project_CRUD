using Microsoft.EntityFrameworkCore;
using Nest;
using NetCore_Project.DTO;
using NetCore_Project.Models;
using System.Linq.Expressions;

namespace NetCore_Project.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        public readonly DbSet<TEntity> _dbSet;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public async Task<int> CountAll()
        {
            return _dbSet.Count();
        }
        public int Count()
        {
            return _dbSet.Count();
        }
        public IEnumerable<TEntity> List()
        {
            return _dbSet.ToList();
        }
        public TEntity Get(long id)
        {
            return _dbSet.Find(id)!;
        }

        //public TEntity GetGuidId(Guid id)
        //{
        //    return _dbSet.FirstOrDefault(entity => entity.MasterId == id);
        //}
        public async Task<TEntity> Create(TEntity entity)
        {
            _dbSet.Add(entity);
            return entity;
        }

        public async Task<List<TEntity>> CreateMany(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
            _context.SaveChanges();
            return entities.ToList();
        }
        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task DeleteMany(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public int CountAll(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.Count();
        }
        public IEnumerable<TEntity> DynamicFind(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.Where(filter);
        }

        public IEnumerable<TEntity> OrFilter(params Expression<Func<TEntity, bool>>[] filters)
        {
            if (filters.Length == 0)
                return Enumerable.Empty<TEntity>();

            var combinedFilter = filters[0];
            for (int i = 1; i < filters.Length; i++)
            {
                combinedFilter = Expression.Lambda<Func<TEntity, bool>>(
                    Expression.OrElse(combinedFilter.Body, filters[i].Body),
                    combinedFilter.Parameters);
            }

            var filterExpression = Expression.Lambda<Func<TEntity, bool>>(combinedFilter, filters[0].Parameters);
            return _dbSet.Where(filterExpression);
        }

        public IEnumerable<TEntity> DynamicOrder(string property, bool isAscending)
        {
            var entityType = typeof(TEntity);
            var parameter = Expression.Parameter(entityType, "x");
            var propertyExpression = Expression.Property(parameter, property);
            var lambdaExpression = Expression.Lambda<Func<TEntity, dynamic>>(propertyExpression, parameter);

            return isAscending
                ? _dbSet.OrderBy(lambdaExpression)
                : _dbSet.OrderByDescending(lambdaExpression);
        }
    }

}
