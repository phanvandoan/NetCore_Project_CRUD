using NetCore_Project.DTO.Invoice;

namespace NetCore_Project.IServices
{
    public interface IInvoiceService
    {
        Task<InvoiceDto> Create(InvoiceDto dto);
    }
}
