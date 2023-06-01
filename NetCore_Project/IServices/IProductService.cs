using Microsoft.AspNetCore.Mvc;
using NetCore_Project.DTO.PagedResult;
using NetCore_Project.DTO.Products;
using NetCore_Project.Models;
using NetCore_Project.Repository;

namespace NetCore_Project.IServices
{
    //public interface IProductService : IRepository<ProductDto>
    public interface IProductService
    {
        IQueryable<ProductDto> GetCount();
        PagedResultDto<ProductDto> GetListProduct(FilterDto dto, int pageIndex, int pageSize);
        Task<ProductDto> GetProductById(long id);
        Task<ProductDto> Create(ProductDto dto);
        Task<Product> update(long id, ProductDto dto);
        Task<string> Delete(long id);
        int Count(FilterDto dto);
    }
}
