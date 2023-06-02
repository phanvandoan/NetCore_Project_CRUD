using AutoMapper;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Nest;
using NetCore_Project.DTO;
using NetCore_Project.DTO.DataDTO;
using NetCore_Project.DTO.FilterDTO;
using NetCore_Project.Models;
using NetCore_Project.Services;
using Newtonsoft.Json.Linq;
using System.Linq.Expressions;
using System.Text.Json.Nodes;
using TrueSight.Common;

namespace NetCore_Project.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<int> Count([FromQuery] ProductFilterDto filterDto)
        {
            var productEntity = ConvertDtoToEntity.ConvertToEntity<ProductFilterDto, Product>(filterDto);
            var count = await _productService.Count(productEntity);
            return 0;
        }

        [HttpGet]
        public ProductDto Get(long id)
        {
            var product = _productService.Get(id);
            var productDto = ConvertDtoToEntity.ConvertToDto<Product, ProductDto>(product);
            return productDto;
        }

        [HttpPost]
        public async Task<ProductDto> Create(ProductDto dto)
        {
            var productEntity = ConvertDtoToEntity.ConvertToEntity<ProductDto, Product>(dto);
            var rsProduct = await _productService.Create(productEntity);
            var productDto = ConvertDtoToEntity.ConvertToDto<Product, ProductDto>(rsProduct);
            return productDto;
        }
        [HttpPut]
        public async Task<ProductDto> Update(long id ,ProductDto dto)
        {
            var rs = await _productService.Update(id, dto);
            var productDto = ConvertDtoToEntity.ConvertToDto<Product, ProductDto>(rs);

            return productDto;
        }
        [HttpDelete]
        public async Task<string> Delete(long id)
        {
            var rs = await _productService.Delete(id);
            return rs;
        }
    }
}
