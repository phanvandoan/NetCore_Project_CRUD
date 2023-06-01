using Humanizer;
using Microsoft.AspNetCore.Mvc;
using NetCore_Project.DTO.DataDTO;
using NetCore_Project.DTO.FilterDTO;
using NetCore_Project.Models;
using System.Linq.Expressions;

namespace NetCore_Project.Services
{
    public interface IProductService
    {
        Task<int> CountAll(Expression<Func<ProductFilterDto, bool>> filter = null);
        //Task<int> CountAll1(Expression<Func<Product, bool>> filter = null);
        //PagedResultDto<ProductDto> GetListProduct(ProductFilterDto dto, int pageIndex, int pageSize);
        //Task<ProductDto> GetProductById(long id);
        ////Task<ProductDto> Create(ProductDto dto);
        //Task<ProductDto> CreateProduct(ProductDto product);
        //Task<Product> update(long id, ProductDto dto);
        //Task<string> Delete(long id);
    }
}
