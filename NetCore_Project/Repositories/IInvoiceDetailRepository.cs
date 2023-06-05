using NetCore_Project.Models;

namespace NetCore_Project.Repositories
{
    public interface IInvoiceDetailRepository : IGenericRepository<InvoiceDetail>
    {
        InvoiceDetail GetByGuidId(Guid id);
        //List<InvoiceDetail> GetListByIdsAsync(Guid ids);
        Task<IEnumerable<InvoiceDetail>> GetEntitiesToDelete(Guid ids);
    }
}
