using System;
using System.Collections.Generic;

namespace NetCore_Project.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Invoices = new HashSet<Invoice>();
        }

        public long Id { get; set; }
        public long? StatusId { get; set; }
        public Guid? RowId { get; set; }
        public bool? Used { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? CustomerNo { get; set; }
        public string? CustomerFirstName { get; set; }
        public string? CustomerLastName { get; set; }
        public string? CustomerCompany { get; set; }
        public string? CustomerAddress { get; set; }
        public string? CustomerDistrict { get; set; }
        public string? CustomerCity { get; set; }
        public long? CustomerAccountNo { get; set; }
        public string? CustomerTaxNo { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
