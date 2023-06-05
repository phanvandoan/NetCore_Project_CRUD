using NetCore_Project.DTO.DataDTO;
using NetCore_Project.DTO.FilterDTO;
using NetCore_Project.Models;
using System.Linq.Expressions;

namespace NetCore_Project.Services
{
    public interface IInvoiceService
    {
        Task<int> Count(Expression<Func<Invoice, bool>> filter = null);
        Invoice Get(long id);
        Task<CreateUpdateInvoiceDto> Create(CreateUpdateInvoiceDto masterModel, List<InvoiceDetail> detailModel);
        Task<CreateUpdateInvoiceDto> Update(CreateUpdateInvoiceDto dto, long id);
        //Task<string> Delete(long id);
    }
}
