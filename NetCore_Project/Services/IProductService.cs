using Humanizer;
using Microsoft.AspNetCore.Mvc;
using NetCore_Project.DTO.DataDTO;
using NetCore_Project.DTO.FilterDTO;
using NetCore_Project.Models;
using Newtonsoft.Json.Linq;
using System.Linq.Expressions;
using System.Text.Json.Nodes;

namespace NetCore_Project.Services
{
    public interface IProductService
    {
        Task<int> Count(Expression<Func<Product, bool>> filter = null);
        Product Get(long id);
        //PagedResultDto<ProductDto> GetListProduct(ProductFilterDto dto, int pageIndex, int pageSize);
        //Task<ProductDto> GetProductById(long id);
        Task<Product> Create(Product dto);
        //Task<ProductDto> update(long id, ProductDto dto);
        Task<Product> Update(long id, ProductDto dto);
        Task<string> Delete(long id);
    }
}
