using NetCore_Project.DTO.Customer;
using NetCore_Project.Models;

namespace NetCore_Project.IServices
{
    public interface ICustomerService
    {
        List<CustomerDto> GetListCustomer(CustomerFilterDto dto);
        Task<CustomerDto> GetCustomerById(long id);
        Task<CustomerDto> Create(CustomerDto dto);
        Task<Customer> update(long id, CustomerDto dto);
        Task<string> Delete(long id);
    }
}
