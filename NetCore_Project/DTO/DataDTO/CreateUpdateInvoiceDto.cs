using NetCore_Project.Models;

namespace NetCore_Project.DTO.DataDTO
{
    public class CreateUpdateInvoiceDto: BaseModel
    {
        public string? InvoiceNo { get; set; }
        public Guid MasterId { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string? PaymentMethod { get; set; }
        public string? Vat { get; set; }
        public long? CustomerId { get; set; }
        public virtual List<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
