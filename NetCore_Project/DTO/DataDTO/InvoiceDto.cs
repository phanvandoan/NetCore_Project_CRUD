
using NetCore_Project.Models;
using SharpCompress.Common;

namespace NetCore_Project.DTO.DataDTO
{
    public class InvoiceDto : BaseModel
    {
        public string? InvoiceNo { get; set; }
        public Guid? MasterId { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string? PaymentMethod { get; set; }
        public string? Vat { get; set; }
        public long? CustomerId { get; set; }

        public virtual ICollection<InvoiceDetailDto> InvoiceDetails { get; set; }

        public InvoiceDto(Invoice invoice)
        {
            Id = invoice.Id;
            StatusId = invoice.StatusId;
            RowId = invoice.RowId;
            Used = invoice.Used;
            CreatedAt = invoice.CreatedAt;
            UpdatedAt = invoice.UpdatedAt;
            DeletedAt = invoice.DeletedAt;
            InvoiceNo = invoice.InvoiceNo;
            InvoiceDate = invoice.InvoiceDate;
            PaymentMethod = invoice.PaymentMethod;
            Vat = invoice.Vat;
            CustomerId = invoice.CustomerId;
            MasterId = invoice.MasterId;
        }
    }
}
