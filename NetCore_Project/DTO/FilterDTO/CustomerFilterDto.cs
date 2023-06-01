using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace NetCore_Project.DTO.FilterDTO
{
    public class CustomerFilterDto
    {
        public string? CustomerNo { get; set; }
        public string? CustomerTaxNo { get; set; }
        public long? Id { get; set; }
        public long? StatusId { get; set; }
    }
}
