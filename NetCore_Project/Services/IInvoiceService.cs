using NetCore_Project.DTO.DataDTO;
using NetCore_Project.DTO.FilterDTO;

namespace NetCore_Project.Services
{
    public interface IInvoiceService
    {
        Task<InvoiceDto> GetInvoiceById(long id);
        PagedResultDto<InvoiceDto> GetListInvoice(InvoiceFilterDto dto, int pageIndex, int pageSize);
        Task<InvoiceDto> Create(InvoiceDto dto);
    }
}
