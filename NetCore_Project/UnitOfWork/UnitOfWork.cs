using Microsoft.EntityFrameworkCore;
using NetCore_Project.DTO;
using NetCore_Project.Models;
using NetCore_Project.Repository;

namespace NetCore_Project.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork

    {
        private readonly ExampleDbContext _context;
        private readonly Dictionary<Type, object> _repositories;

        public UnitOfWork(ExampleDbContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }

        public IRepository<T> GetRepository<T>() where T : BaseModel
        {
            if (_repositories.ContainsKey(typeof(T)))
            {
                return (IRepository<T>)_repositories[typeof(T)];
            }

            var repository = new Repository<T>(_context);
            _repositories.Add(typeof(T), repository);
            return repository;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
