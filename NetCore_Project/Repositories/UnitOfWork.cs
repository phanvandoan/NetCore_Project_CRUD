using NetCore_Project.Models;

namespace NetCore_Project.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ExampleDbContext _context;
        private Dictionary<Type, object> _repositories;
        public IProductRepository Products { get; }
        public ICustomerRepository Customers { get; }
        public IInvoiceRepository Invoices { get; }


        public UnitOfWork(ExampleDbContext context,
            IProductRepository products,
            ICustomerRepository customer,
            IInvoiceRepository invoice
            )
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
            Products = products;
            Customers = customer;
            Invoices = invoice;
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            var entityType = typeof(TEntity);

            if (!_repositories.ContainsKey(entityType))
            {
                var repositoryType = typeof(GenericRepository<>).MakeGenericType(entityType);
                var repositoryInstance = Activator.CreateInstance(repositoryType, _context);
                _repositories.Add(entityType, repositoryInstance);
            }

            return (IGenericRepository<TEntity>)_repositories[entityType];
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
