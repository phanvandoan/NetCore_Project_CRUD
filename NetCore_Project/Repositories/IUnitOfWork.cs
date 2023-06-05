using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore_Project.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        int Save();
        void Rollback();
        IProductRepository Products { get; }
        ICustomerRepository Customers { get; }
        IInvoiceRepository Invoices { get; }
        IInvoiceDetailRepository InvoiceDetails { get; }
    }
}
