using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetCore_Project.DTO.DataDTO;
using NetCore_Project.DTO.FilterDTO;
using NetCore_Project.Models;
using NetCore_Project.Repositories;
using System.Linq.Expressions;

namespace NetCore_Project.Services
{
    public class ProductService : IProductService
    {
        //private readonly IGenericRepository<Product> _repository;

        //public ProductService(IGenericRepository<Product> repository)
        //{
        //    _repository = repository;
        //}
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Product> _genericRepository;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _genericRepository = _unitOfWork.GetRepository<Product>();
            _mapper = mapper;
        }

        public async Task<int> CountAll(Expression<Func<ProductFilterDto, bool>> filter = null)
        {
            //var count = await _genericRepository.CountAll(dto);
            Expression<Func<Product, bool>> productFilter = null;
            if (filter != null)
            {
                productFilter = _mapper.Map<Expression<Func<ProductFilterDto, bool>>, Expression<Func<Product, bool>>>(filter);
            }

            return _genericRepository.CountAll(productFilter); ;

        }
        //public async Task<ProductDto> CreateProduct(ProductDto dto)
        //{
        //    throw new NotImplementedException();

        //}

        //public Task<string> Delete(long id)
        //{
        //    throw new NotImplementedException();
        //}

        //public PagedResultDto<ProductDto> GetListProduct(ProductFilterDto dto, int pageIndex, int pageSize)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<ProductDto> GetProductById(long id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Product> update(long id, ProductDto dto)
        //{
        //    throw new NotImplementedException();
        //}
        //public PagedResultDto<ProductDto> GetListProduct(FilterDto dto, int pageIndex, int pageSize)
        //{
        //    var listProduct = Filter(dto, pageIndex, pageSize);
        //    List<ProductDto> productDtos = _mapper.Map<List<ProductDto>>(listProduct);
        //    PagedResultDto<ProductDto> pagedResult = new PagedResultDto<ProductDto>(pageIndex, pageSize, listProduct.Count(), productDtos);
        //    return pagedResult;
        //}
        //public async Task<ProductDto> GetProductById(long id)
        //{
        //    var product = await _context.Customers.FindAsync(id);
        //    ProductDto productDtos = _mapper.Map<ProductDto>(product);
        //    return productDtos;
        //}
        //public async Task<ProductDto> Create(ProductDto dto)
        //{
        //    var productDtos = _mapper.Map<Product>(dto);
        //    await _context.Products.AddAsync(productDtos);
        //    await _context.SaveChangesAsync();
        //    return _mapper.Map<ProductDto>(dto);
        //}

        //public async Task<Product> update(long id, ProductDto dto)
        //{
        //    Product product = await _context.Products.FindAsync(id);
        //    if (product == null)
        //    {
        //        return null;
        //    }
        //    var productDtos = _mapper.Map(dto, product);
        //    await _context.SaveChangesAsync();
        //    return productDtos;
        //}

        //public async Task<string> Delete(long id)
        //{
        //    var product = await GetProductById(id);
        //    try
        //    {
        //        if (product != null)
        //        {
        //            _context.Remove(product);
        //            _context.SaveChanges();
        //        }
        //        return "Deleted Success!";
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }

        //}

        //private List<Product> Filter(FilterDto dto, int pageIndex, int pageSize)
        //{
        //    var query = _context.Products.AsQueryable();
        //    if (dto.Id.HasValue)
        //    {
        //        query = query.Where(entity => entity.Id == dto.Id);
        //    }
        //    if (!string.IsNullOrWhiteSpace(dto.ProductNo))
        //    {
        //        query = query.Where(entity => entity.ProductNo == dto.ProductNo);
        //    }
        //    if (!string.IsNullOrWhiteSpace(dto.ProductName))
        //    {
        //        query = query.Where(entity => entity.ProductName == dto.ProductName);
        //    }
        //    if (!string.IsNullOrWhiteSpace(dto.Unit))
        //    {
        //        query = query.Where(entity => entity.Unit == dto.Unit);
        //    }
        //    if (pageIndex >= 1)
        //    {
        //        query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        //    }
        //    var entities = query.ToList();
        //    return entities;
        //}
    }
}
