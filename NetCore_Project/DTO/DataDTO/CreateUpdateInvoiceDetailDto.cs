namespace NetCore_Project.DTO.DataDTO
{
    public class CreateUpdateInvoiceDetailDto:BaseModel
    {
        public string? InvoiceDetailsNo { get; set; }
        public Guid? MasterId { get; set; }
        public string? SequenceNo { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
