using System;
using System.Collections.Generic;

namespace NetCore_Project.Models
{
    public partial class Invoice
    {
        public long Id { get; set; }
        public long? StatusId { get; set; }
        public Guid? RowId { get; set; }
        public bool? Used { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? InvoiceNo { get; set; }
        public Guid MasterId { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string? PaymentMethod { get; set; }
        public string? Vat { get; set; }
        public long? CustomerId { get; set; }
    }
}
