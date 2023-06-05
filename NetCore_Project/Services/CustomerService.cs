using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NetCore_Project.DTO.DataDTO;
using NetCore_Project.DTO.FilterDTO;
using NetCore_Project.Models;
using NetCore_Project.Repositories;
using NetCore_Project.Services.Valid;
using StackExchange.Redis;
using System.Linq.Expressions;

namespace NetCore_Project.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<Customer> _validator;

        public CustomerService(IUnitOfWork unitOfWork, IValidator<Customer> validator
            )
        {
            _validator = validator;
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Count(Expression<Func<Customer, bool>> filter)
        {
            var count = _unitOfWork.Customers.DynamicFind(filter);
            return count.Count();
        }

        public Customer Get(long id)
        {
            if (id != null)
            {
                var customers = _unitOfWork.Customers.Get(id);
                return customers;
            }
            return null;
        }


        public async Task<(Customer, Dictionary<string, string>)> Create(Customer dto)
        {
            try
            {
                var validationResult = _validator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    var errors = validationResult.Errors.ToDictionary(error => error.ErrorCode, error => error.ErrorMessage);
                    return (null, errors);
                }
                var rs = await _unitOfWork.Customers.Create(dto);
                var result = _unitOfWork.Save();
                return (dto, null);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw ex;
            }
        }

        public async Task<(Customer, Dictionary<string, string>)> Update(long id, Customer dto)
        {
            try
            {
                var customer = _unitOfWork.Customers.Get(id);
                var validationResult = _validator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    var errors = validationResult.Errors.ToDictionary(error => error.ErrorCode, error => error.ErrorMessage);
                    return (null, errors);
                }

                if (customer != null)
                {
                    customer.StatusId = dto.StatusId;
                    customer.RowId = dto.RowId;
                    customer.Used = dto.Used;
                    customer.UpdatedAt = dto.UpdatedAt;
                    customer.CustomerNo = dto.CustomerNo;
                    customer.CustomerFirstName = dto.CustomerFirstName;
                    customer.CustomerLastName = dto.CustomerLastName;
                    customer.CustomerCompany = dto.CustomerCompany;
                    customer.CustomerAddress = dto.CustomerAddress;
                    customer.CustomerDistrict = dto.CustomerDistrict;
                    customer.CustomerCity = dto.CustomerCity;
                    customer.CustomerAccountNo = dto.CustomerAccountNo;
                    customer.CustomerTaxNo = dto.CustomerTaxNo;

                    _unitOfWork.Customers.Update(customer);
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
                var customer = _unitOfWork.Customers.Get(id);
                if (customer != null)
                {
                    _unitOfWork.Customers.Delete(customer);
                    var result = _unitOfWork.Save();
                    message = "Deleted success!";
                    return message;
                }
            }
            return message;
        }

    }
}
