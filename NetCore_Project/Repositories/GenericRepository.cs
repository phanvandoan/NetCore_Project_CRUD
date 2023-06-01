using Microsoft.EntityFrameworkCore;
using NetCore_Project.DTO;
using NetCore_Project.Models;
using System.Linq.Expressions;

namespace NetCore_Project.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

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
        public TEntity Get(int id)
        {
            return _dbSet.Find(id);
        }
        public void Create(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
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
        //public IEnumerable<TEntity> DynamicFind(Expression<Func<TEntity, bool>> filter)
        //{
        //    return _dbSet.Where(filter);
        //}

        //public IEnumerable<TEntity> OrFilter(params Expression<Func<TEntity, bool>>[] filters)
        //{
        //    if (filters.Length == 0)
        //        return Enumerable.Empty<TEntity>();

        //    var combinedFilter = filters[0];
        //    for (int i = 1; i < filters.Length; i++)
        //    {
        //        combinedFilter = Expression.Lambda<Func<TEntity, bool>>(
        //            Expression.OrElse(combinedFilter.Body, filters[i].Body),
        //            combinedFilter.Parameters);
        //    }

        //    var filterExpression = Expression.Lambda<Func<TEntity, bool>>(combinedFilter, filters[0].Parameters);
        //    return _dbSet.Where(filterExpression);
        //}

        //public IEnumerable<TEntity> DynamicOrder(string property, bool isAscending)
        //{
        //    var entityType = typeof(TEntity);
        //    var parameter = Expression.Parameter(entityType, "x");
        //    var propertyExpression = Expression.Property(parameter, property);
        //    var lambdaExpression = Expression.Lambda<Func<TEntity, dynamic>>(propertyExpression, parameter);

        //    return isAscending
        //        ? _dbSet.OrderBy(lambdaExpression)
        //        : _dbSet.OrderByDescending(lambdaExpression);
        //}
    }

}
