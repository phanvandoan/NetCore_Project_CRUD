using NetCore_Project.Models;

namespace NetCore_Project.DTO.DataDTO
{
    public class ProductDto : BaseModel
    {
        public string? ProductNo { get; set; }
        public string? ProductName { get; set; }
        public string? Unit { get; set; }

        public ProductDto(Product product)
        {
            Id = product.Id;
            StatusId = product.StatusId;
            RowId = product.RowId;
            Used = product.Used;
            CreatedAt = product.CreatedAt;
            UpdatedAt = product.UpdatedAt;
            DeletedAt = product.DeletedAt;
            ProductNo = product.ProductNo;
            ProductName = product.ProductName;
            Unit = product.Unit;
        }
    }
}
