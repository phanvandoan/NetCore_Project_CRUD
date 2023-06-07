using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetCore_Project.DTO;
using NetCore_Project.DTO.DataDTO;
using NetCore_Project.DTO.FilterDTO;
using NetCore_Project.Models;
using NetCore_Project.Services;
using System.Linq;
using System.Linq.Expressions;

namespace NetCore_Project.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<int> Count([FromQuery] ProductFilterDto filterDto)
        {
            var count = await _productService.Count(filterDto);
            return count;
        }

        [HttpGet]
        public List<ProductDto> List([FromQuery] ProductFilterDto filterDto)
        {
            var products = _productService.List(filterDto);
            List<ProductDto> rs = MapEntitiesToDTOs(products);
            return rs;
        }
        [HttpGet]
        public ProductDto Get(long id)
        {
            var product = _productService.Get(id);
            ProductDto productDto = new ProductDto(product);
            return productDto;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto dto)
        {
            var productEntity = ConvertDtoToEntity.ConvertToEntity<ProductDto, Product>(dto);
            var (rsProduct, errors) = await _productService.Create(productEntity);
            if (errors != null)
            {
                return BadRequest(errors);
            }

            return Ok(rsProduct);
        }
        [HttpPut]
        public async Task<IActionResult> Update(long id ,ProductDto dto)
        {
            var productEntity = ConvertDtoToEntity.ConvertToEntity<ProductDto, Product>(dto);
            var (rs, errors) = await _productService.Update(id, productEntity);

            if (errors != null)
            {
                return BadRequest(errors);
            }
            return Ok(rs);
        }
        [HttpDelete]
        public async Task<string> Delete(long id)
        {
            var rs = await _productService.Delete(id);
            return rs;
        }

        private List<ProductDto> MapEntitiesToDTOs(List<Product> entities)
        {
            List<ProductDto> dtos = entities.Select(entity => new ProductDto(entity)).ToList();
            return dtos;
        }
    }
}
