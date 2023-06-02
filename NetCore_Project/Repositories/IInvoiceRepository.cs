using NetCore_Project.Models;

namespace NetCore_Project.Repositories
{
    public interface IInvoiceRepository : IGenericRepository<Invoice>
    {
    }

    public interface IInvoiceDetailRepository : IGenericRepository<InvoiceDetail>
    {
    }
}
