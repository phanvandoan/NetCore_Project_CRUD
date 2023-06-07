using NetCore_Project.DTO.DataDTO;
using NetCore_Project.DTO.FilterDTO;
using NetCore_Project.Models;
using System.Linq.Expressions;

namespace NetCore_Project.Services
{
    public interface ICustomerService
    {
        Task<int> Count(CustomerFilterDto filter);
        Customer Get(long id);
        List<Customer> List(CustomerFilterDto filter);
        Task<(Customer, Dictionary<string, string>)> Create(Customer dto);
        Task<(Customer, Dictionary<string, string>)> Update(long id, Customer dto);
        Task<string> Delete(long id);
    }
}
