namespace NetCore_Project.DTO.Products
{
    public class ProductDto : BaseModel
    {
        public string? ProductNo { get; set; }
        public string? ProductName { get; set; }
        public string? Unit { get; set; }
    }
}
