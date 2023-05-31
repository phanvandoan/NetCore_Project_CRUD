using Microsoft.AspNetCore.Mvc;
using NetCore_Project.DTO.Products;
using NetCore_Project.IServices;
using NetCore_Project.Models;
using Newtonsoft.Json.Serialization;
using AutoMapper;
using SharpCompress.Common;
using NetCore_Project.DTO.Customer;
using Newtonsoft.Json;

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

        public IQueryable<List<ProductDto>> GetListProduct(FilterDto dto)
        {
            return null;
        }
        public async Task<ProductDto> GetProductById(long id)
        {
            ProductDto res = new();
            var product = await _context.Customers.FindAsync(id);
            var json = JsonConvert.SerializeObject(product);
            res = JsonConvert.DeserializeObject<ProductDto>(json);
            return res;
        }


        public async Task<ProductDto> Create(ProductDto dto)
        {
            ProductDto res = new();
            var products = new Product()
            {
                StatusId = dto.StatusId,
                RowId = Guid.NewGuid(),
                Used = dto.Used,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt,
                DeletedAt = dto.DeletedAt,
                ProductNo = dto.ProductNo,
                ProductName = dto.ProductName,
                Unit = dto.Unit,
            };
            var json = JsonConvert.SerializeObject(products);
            res = JsonConvert.DeserializeObject<ProductDto>(json);

            await _context.Products.AddAsync(products);
            await _context.SaveChangesAsync();
            return res;
        }

        public async Task<Product> update(long id, ProductDto dto)
        {
            Product product = await _context.Products!.FindAsync(id);
            if (product != null)
            {
                product.StatusId = dto.StatusId;
                product.RowId = dto.RowId;
                product.Used = dto.Used;
                product.CreatedAt = dto.CreatedAt;
                product.UpdatedAt = dto.UpdatedAt;
                product.DeletedAt = dto.DeletedAt;
                product.ProductNo = dto.ProductNo;
                product.ProductName = dto.ProductName;
                product.Unit = dto.Unit;
                await _context.SaveChangesAsync();
            }
            else
            {

            }
            return product;
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
    }
}
