using NetCore_Project.DTO.DataDTO;
using NetCore_Project.DTO.FilterDTO;
using NetCore_Project.Models;
using System.Linq.Expressions;

namespace NetCore_Project.Services
{
    public interface ICustomerService
    {
        Task<int> Count(Expression<Func<Customer, bool>> filter = null);
        Customer Get(long id);
        Task<(Customer, Dictionary<string, string>)> Create(Customer dto);
        Task<(Customer, Dictionary<string, string>)> Update(long id, Customer dto);
        Task<string> Delete(long id);
    }
}
