using NetCore_Project.Models;
using SharpCompress.Common;

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


        public CustomerDto(Customer entity)
        {
            Id = entity.Id;
            StatusId = entity.StatusId;
            RowId = entity.RowId;
            Used =  entity.Used;
            CreatedAt = entity.CreatedAt;
            UpdatedAt = entity.UpdatedAt;
            DeletedAt = entity.DeletedAt;
            CustomerNo = entity.CustomerNo;
            CustomerFirstName = entity.CustomerFirstName;
            CustomerLastName = entity.CustomerLastName;
            CustomerCompany = entity.CustomerCompany;
            CustomerAddress = entity.CustomerAddress;
            CustomerDistrict = entity.CustomerDistrict;
            CustomerCity = entity.CustomerCity;
            CustomerAccountNo = entity.CustomerAccountNo;
            CustomerTaxNo = entity.CustomerTaxNo;
        }
        
    }



}
