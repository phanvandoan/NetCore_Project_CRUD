using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nest;
using NetCore_Project.DTO.DataDTO;
using NetCore_Project.DTO.FilterDTO;
using NetCore_Project.Models;
using NetCore_Project.Services;
using SmartFormat.Core.Output;
using System.Linq.Expressions;
using System.Text.Json.Nodes;

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
        public async Task<int> CountAll([FromQuery] ProductFilterDto filterDto)
        {
            var filterExpression = _mapper.Map<Expression<Func<ProductFilterDto, bool>>>(filterDto);
            int count = await _productService.CountAll(filterExpression);
            return count;
        }

        //[HttpGet]
        //public IQueryable<ProductDto> Get(long id)
        //{
        //    return null;
        //}

        ////[HttpPost]
        ////public async Task<ProductDto> Create(ProductDto dto)
        ////{
        ////    return await _productService.Create(dto);
        ////}
        //[HttpPost]
        //public async Task<ProductDto> CreateProduct(ProductDto dto)
        //{
        //    return await _productService.CreateProduct(dto);
        //}

        //[HttpPut]
        //public async Task<Product> Update(long id, ProductDto dto)
        //{
        //    return await _productService.update(id, dto);
        //}

        //[HttpDelete]
        //public async Task<string> Delete(long id)
        //{
        //    return await _productService.Delete(id);
        //}
    }
}
