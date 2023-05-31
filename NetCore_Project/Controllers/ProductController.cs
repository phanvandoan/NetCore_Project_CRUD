using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nest;
using NetCore_Project.DTO.Products;
using NetCore_Project.IServices;
using NetCore_Project.Models;
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
        public async Task<List<ProductDto>> List(FilterDto dto)
        {
            return null;
        }

        [HttpGet]
        public IQueryable<ProductDto> Get(long id)
        {
            return null;
        }

        [HttpPost]
        public Task<ProductDto> Create(ProductDto dto)
        {

            return _productService.Create(dto);
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
    }
}
