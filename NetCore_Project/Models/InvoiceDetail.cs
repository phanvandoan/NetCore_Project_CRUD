using System;
using System.Collections.Generic;

namespace NetCore_Project.Models
{
    public partial class InvoiceDetail
    {
        public long Id { get; set; }
        public long? StatusId { get; set; }
        public Guid? RowId { get; set; }
        public bool? Used { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? InvoiceDetailsNo { get; set; }
        public Guid? MasterId { get; set; }
        public string? SequenceNo { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public long? ProductId { get; set; }
    }
}
