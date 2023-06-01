using Microsoft.AspNetCore.Mvc;
using NetCore_Project.DTO.Products;
using NetCore_Project.IServices;
using NetCore_Project.Models;
using Newtonsoft.Json.Serialization;
using AutoMapper;
using SharpCompress.Common;
using NetCore_Project.DTO.Customer;
using Newtonsoft.Json;
using NetCore_Project.DTO.PagedResult;
using System.Drawing.Printing;

namespace NetCore_Project.Services
{
    public class ProductService : IProductService
    {
        private readonly ExampleDbContext _context;
        private readonly IMapper _mapper;
        public ProductService(ExampleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IQueryable<ProductDto> GetCount()
        {
            return null;
        }

        public PagedResultDto<ProductDto> GetListProduct(FilterDto dto, int pageIndex, int pageSize)
        {
            var listProduct = Filter(dto, pageIndex, pageSize);
            List<ProductDto> productDtos = _mapper.Map<List<ProductDto>>(listProduct);
            PagedResultDto<ProductDto> pagedResult = new PagedResultDto<ProductDto>(pageIndex, pageSize, listProduct.Count(), productDtos);
            return pagedResult;
        }
        public async Task<ProductDto> GetProductById(long id)
        {
            var product = await _context.Customers.FindAsync(id);
            ProductDto productDtos = _mapper.Map<ProductDto>(product);
            return productDtos;
        }
        public async Task<ProductDto> Create(ProductDto dto)
        {
            var productDtos = _mapper.Map<Product>(dto);
            await _context.Products.AddAsync(productDtos);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDto>(dto);
        }

        public async Task<Product> update(long id, ProductDto dto)
        {
            Product product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return null;
            }
            var productDtos = _mapper.Map(dto, product);
            await _context.SaveChangesAsync();
            return productDtos;
        }

        public async Task<string> Delete(long id)
        {
            var product = await GetProductById(id);
            try
            {
                if (product != null)
                {
                    _context.Remove(product);
                    _context.SaveChanges();
                }
                return "Deleted Success!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        private List<Product> Filter(FilterDto dto, int pageIndex, int pageSize)
        {
            var query = _context.Products.AsQueryable();
            if (dto.Id.HasValue)
            {
                query = query.Where(entity => entity.Id == dto.Id);
            }
            if (!string.IsNullOrWhiteSpace(dto.ProductNo))
            {
                query = query.Where(entity => entity.ProductNo == dto.ProductNo);
            }
            if (!string.IsNullOrWhiteSpace(dto.ProductName))
            {
                query = query.Where(entity => entity.ProductName == dto.ProductName);
            }
            if (!string.IsNullOrWhiteSpace(dto.Unit))
            {
                query = query.Where(entity => entity.Unit == dto.Unit);
            }
            if (pageIndex >= 1)
            {
                query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            var entities = query.ToList();
            return entities;
        }
    }
}
