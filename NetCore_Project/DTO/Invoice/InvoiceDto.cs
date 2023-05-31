﻿using NetCore_Project.DTO.Invoice.InvoiceDetails;
using NetCore_Project.Models;

namespace NetCore_Project.DTO.Invoice
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
    }
}
