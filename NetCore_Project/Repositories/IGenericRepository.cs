using System.Linq.Expressions;

namespace NetCore_Project.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<int> CountAll();
        int Count();
        IEnumerable<TEntity> List();
        TEntity Get(long id);
        Task<TEntity> Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        int CountAll(Expression<Func<TEntity, bool>> filter = null);
        IEnumerable<TEntity> DynamicFind(Expression<Func<TEntity, bool>> filter);
        IEnumerable<TEntity> OrFilter(params Expression<Func<TEntity, bool>>[] filters);
        IEnumerable<TEntity> DynamicOrder(string property, bool isAscending);
    }
}
