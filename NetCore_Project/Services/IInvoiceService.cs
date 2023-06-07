using NetCore_Project.DTO.DataDTO;
using NetCore_Project.DTO.FilterDTO;
using NetCore_Project.Models;
using System.Linq.Expressions;

namespace NetCore_Project.Services
{
    public interface IInvoiceService
    {
        List<Invoice> List(InvoiceFilterDto filter);
        Task<int> Count(InvoiceFilterDto filter);
        Task<CreateUpdateInvoiceDto> Get(long id);
        Task<(CreateUpdateInvoiceDto, Dictionary<string, string>)> Create(CreateUpdateInvoiceDto masterModel, List<InvoiceDetail> detailModel);
        Task<(CreateUpdateInvoiceDto, Dictionary<string, string>)> Update(CreateUpdateInvoiceDto dto, long id);
        Task<string> Delete(long id);
    }
}
