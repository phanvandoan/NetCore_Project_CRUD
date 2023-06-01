using NetCore_Project.DTO;
using NetCore_Project.Repository;

namespace NetCore_Project.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : BaseModel;
        void SaveChanges();
    }
}
