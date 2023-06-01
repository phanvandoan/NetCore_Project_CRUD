using NetCore_Project.DTO.DataDTO;
using NetCore_Project.DTO.FilterDTO;
using NetCore_Project.Models;

namespace NetCore_Project.Services
{
    public interface ICustomerService
    {
        PagedResultDto<CustomerDto> GetListCustomer(CustomerFilterDto dto, int pageIndex, int pageSize);
        Task<CustomerDto> GetCustomerById(long id);
        Task<CustomerDto> Create(CustomerDto dto);
        Task<Customer> update(long id, CustomerDto dto);
        Task<string> Delete(long id);
    }
}
