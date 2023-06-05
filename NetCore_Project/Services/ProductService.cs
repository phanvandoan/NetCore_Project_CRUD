using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NetCore_Project.DTO.DataDTO;
using NetCore_Project.DTO.FilterDTO;
using NetCore_Project.Models;
using NetCore_Project.Repositories;
using Newtonsoft.Json.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text.Json.Nodes;

namespace NetCore_Project.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<Product> _validator;
        public ProductService(IUnitOfWork unitOfWork, IValidator<Product> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }
        public async Task<int> Count(Expression<Func<Product, bool>> filter)
        {
            var count = _unitOfWork.Products.DynamicFind(filter);
            return count.Count();
        }

        public Product Get(long id)
        {
            if (id != null)
            {
                var products = _unitOfWork.Products.Get(id);
                return products;
            }
            return null;
        }


        public async Task<(Product, Dictionary<string, string>)> Create(Product dto)
        {
            try
            {
                var validationResult = _validator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    var errors = validationResult.Errors.ToDictionary(error => error.ErrorCode, error => error.ErrorMessage);
                    return (null, errors);
                }
                var rs = await _unitOfWork.Products.Create(dto);
                var result = _unitOfWork.Save();
                return (dto, null);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw ex;
            }
            

        }

        public async Task<(Product, Dictionary<string, string>)> Update(long id, Product dto)
        {
            var product = _unitOfWork.Products.Get(id);
            try
            {
                var validationResult = _validator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    var errors = validationResult.Errors.ToDictionary(error => error.ErrorCode, error => error.ErrorMessage);
                    return (null, errors);
                }
                if (product != null)
                {
                    product.StatusId = dto.StatusId;
                    product.RowId = dto.RowId;
                    product.Used = dto.Used;
                    product.UpdatedAt = dto.UpdatedAt;
                    product.ProductName = dto.ProductName;
                    product.ProductNo = dto.ProductNo;
                    product.Unit = dto.Unit;
                    _unitOfWork.Products.Update(product);
                    _unitOfWork.Save();
                    return (dto, null);
                }
                return (dto, null);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw ex;
            }
            
        }

        public async Task<string> Delete(long id)
        {
            string message = null;
            if (id != 0)
            {
                var product = _unitOfWork.Products.Get(id);
                if (product != null)
                {
                    _unitOfWork.Products.Delete(product);
                    var result = _unitOfWork.Save();
                    message = "Deleted success!";
                    return message;
                }
            }
            return message;
        }
    }
}
