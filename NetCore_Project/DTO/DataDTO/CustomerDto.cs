namespace NetCore_Project.DTO.DataDTO
{
    public class CustomerDto : BaseModel
    {
        public string? CustomerNo { get; set; }
        public string? CustomerFirstName { get; set; }
        public string? CustomerLastName { get; set; }
        public string? CustomerCompany { get; set; }
        public string? CustomerAddress { get; set; }
        public string? CustomerDistrict { get; set; }
        public string? CustomerCity { get; set; }
        public long? CustomerAccountNo { get; set; }
        public string? CustomerTaxNo { get; set; }
    }
}
