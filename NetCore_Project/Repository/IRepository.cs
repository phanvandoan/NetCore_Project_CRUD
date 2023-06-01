using NetCore_Project.DTO;
using System.Linq.Expressions;

namespace NetCore_Project.Repository
{
    public interface IRepository<T> where T : BaseModel
    {
        int CountAll();
        int Count(Expression<Func<T, bool>> filter = null);
        IQueryable<T> GetAll();
        T Get(int id, bool isActive = true);
        void Insert(T entity, bool saveChange = true);
        void Update(T entity, bool saveChange = true);
        void Delete(T entity, bool saveChange = true);
    }
}
