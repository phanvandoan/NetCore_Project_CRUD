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
        //PagedResultDto<ProductDto> GetListProduct(ProductFilterDto dto, int pageIndex, int pageSize);
        //Task<ProductDto> GetProductById(long id);
        Task<Customer> Create(Customer dto);
        //Task<ProductDto> update(long id, ProductDto dto);
        Task<Customer> Update(long id, CustomerDto dto);
        Task<string> Delete(long id);
    }
}
