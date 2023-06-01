using NetCore_Project.DTO.Customer;
using NetCore_Project.DTO.Invoice;
using NetCore_Project.DTO.PagedResult;

namespace NetCore_Project.IServices
{
    public interface IInvoiceService
    {
        Task<InvoiceDto> GetInvoiceById(long id);
        PagedResultDto<InvoiceDto> GetListInvoice(InvoiceFilterDto dto, int pageIndex, int pageSize);
        Task<InvoiceDto> Create(InvoiceDto dto);
    }
}
