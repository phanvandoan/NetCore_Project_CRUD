using System;
using System.Collections.Generic;

namespace NetCore_Project.Models
{
    public partial class Product
    {
        public long Id { get; set; }
        public long? StatusId { get; set; }
        public Guid? RowId { get; set; }
        public bool? Used { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? ProductNo { get; set; }
        public string? ProductName { get; set; }
        public string? Unit { get; set; }
    }
}
