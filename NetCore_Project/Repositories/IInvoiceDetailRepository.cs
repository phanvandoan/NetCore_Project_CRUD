using NetCore_Project.Models;

namespace NetCore_Project.Repositories
{
    public interface IInvoiceDetailRepository : IGenericRepository<InvoiceDetail>
    {
        //InvoiceDetail GetByGuidId(Guid id);
        Task<List<InvoiceDetail>> GetListByIdsAsync(Guid ids);
        void DeleteMany(IEnumerable<long> ids);
    }
}
