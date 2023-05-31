using Microsoft.AspNetCore.Mvc;
using NetCore_Project.DTO.Products;
using NetCore_Project.Models;

namespace NetCore_Project.IServices
{
    public interface IProductService
    {
        IQueryable<ProductDto> GetCount();
        IQueryable<List<ProductDto>> GetListProduct(FilterDto dto);
        Task<ProductDto> GetProductById(long id);
        Task<ProductDto> Create(ProductDto dto);
        Task<Product> update(long id, ProductDto dto);
        Task<string> Delete(long id);
    }
}
