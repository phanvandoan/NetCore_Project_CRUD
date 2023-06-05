using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NetCore_Project.DTO;
using NetCore_Project.DTO.DataDTO;
using NetCore_Project.DTO.FilterDTO;
using NetCore_Project.Models;
using NetCore_Project.Services;
using System.Linq.Expressions;

namespace NetCore_Project.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<int> Count([FromQuery] CustomerFilterDto filterDto)
        {
            //Expression<Func<Product, bool>> filterExpression = GenerateFilterExpression<Product>(filterExpression);
            //var productDTOs = await _productService.Count(filterExpression);
            //return productDTOs;
            return 0;
        }
        public static Expression<Func<TDto, bool>> GenerateFilterExpression<TDto>(TDto entityDto)
        {
            var parameter = Expression.Parameter(typeof(TDto), "dto");

            Expression filterExpression = null;

            foreach (var property in typeof(TDto).GetProperties())
            {
                var propertyValue = property.GetValue(entityDto);
                if (propertyValue != null)
                {
                    var propertyExpression = Expression.Property(parameter, property);
                    var filterValue = Expression.Constant(propertyValue);
                    var equalityExpression = Expression.Equal(propertyExpression, filterValue);

                    filterExpression = filterExpression == null
                        ? equalityExpression
                        : Expression.AndAlso(filterExpression, equalityExpression);
                }
            }

            if (filterExpression == null)
                return null;

            var lambda = Expression.Lambda<Func<TDto, bool>>(filterExpression, parameter);
            return lambda;
        }

        [HttpGet]
        public CustomerDto Get(long id)
        {
            var customer = _customerService.Get(id);
            var customerDto = ConvertDtoToEntity.ConvertToDto<Customer, CustomerDto>(customer);
            return customerDto;
        }

        [HttpPost]
        public async Task<CustomerDto> Create(CustomerDto dto)
        {
            var customerEntity = ConvertDtoToEntity.ConvertToEntity<CustomerDto, Customer>(dto);
            var rsCustomer = await _customerService.Create(customerEntity);
            var customerDto = ConvertDtoToEntity.ConvertToDto<Customer, CustomerDto>(rsCustomer);
            return customerDto;
        }
        [HttpPut]
        public async Task<CustomerDto> Update(long id, CustomerDto dto)
        {
            var rs = await _customerService.Update(id, dto);
            var customerDto = ConvertDtoToEntity.ConvertToDto<Customer, CustomerDto>(rs);

            return customerDto;
        }
        [HttpDelete]
        public async Task<string> Delete(long id)
        {
            var rs = await _customerService.Delete(id);
            return rs;
        }
    }
}
