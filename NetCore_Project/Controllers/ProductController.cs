using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nest;
using NetCore_Project.DTO.Customer;
using NetCore_Project.DTO.PagedResult;
using NetCore_Project.DTO.Products;
using NetCore_Project.IServices;
using NetCore_Project.Models;
using NetCore_Project.Services;
using SmartFormat.Core.Output;
using System.Text.Json.Nodes;

namespace NetCore_Project.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Count()
        {
            return null;
        }
        [HttpGet]
        [HttpGet]
        public PagedResultDto<ProductDto> List([FromQuery] FilterDto dto, int pageIndex, int pageSize)
        {
            return _productService.GetListProduct(dto, pageIndex, pageSize);
        }

        [HttpGet]
        public IQueryable<ProductDto> Get(long id)
        {
            return null;
        }

        [HttpPost]
        public async Task<ProductDto> Create(ProductDto dto)
        {
            return await _productService.Create(dto);
        }

        [HttpPut]
        public async Task<Product> Update(long id, ProductDto dto)
        {
            return await _productService.update(id, dto);
        }

        [HttpDelete]
        public async Task<string> Delete(long id)
        {
            return await _productService.Delete(id);
        }

        [HttpGet]
        public int GetCount(FilterDto dto)
        {
            return _productService.Count(dto);
        }
    }
}
