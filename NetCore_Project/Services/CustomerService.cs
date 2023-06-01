using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nest;
using NetCore_Project.DTO.Customer;
using NetCore_Project.DTO.PagedResult;
using NetCore_Project.IServices;
using NetCore_Project.Models;
using Newtonsoft.Json;
using System.Drawing.Printing;
using System.Net.NetworkInformation;
using static StackExchange.Redis.Role;

namespace NetCore_Project.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ExampleDbContext _context;
        private readonly IMapper _mapper;
        public CustomerService(ExampleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public PagedResultDto<CustomerDto> GetListCustomer(CustomerFilterDto dto, int pageIndex, int pageSize)
        {
            var listCustomer = Filter(dto, pageIndex, pageSize);
            List<CustomerDto> customerDtos = _mapper.Map<List<CustomerDto>>(listCustomer);
            PagedResultDto<CustomerDto> pagedResult = new PagedResultDto<CustomerDto>(pageIndex, pageSize, listCustomer.Count(), customerDtos);
            return pagedResult;
        }

        public async Task<CustomerDto> GetCustomerById(long id)
        {
            try
            {
                var customer = await _context.Customers.FindAsync(id);
                CustomerDto customerDtos = _mapper.Map<CustomerDto>(customer);
                return customerDtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CustomerDto> Create(CustomerDto dto)
        {
            try
            {
                var customerDtos = _mapper.Map<Customer>(dto);
                await _context.Customers.AddAsync(customerDtos);
                await _context.SaveChangesAsync();
                return _mapper.Map<CustomerDto>(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<Customer> update(long id, CustomerDto dto)
        {
            try
            {
                Customer customer = await _context.Customers.FindAsync(id);
                if (customer == null)
                {
                    return null;

                }
                var customerDtos = _mapper.Map(dto, customer);
                await _context.SaveChangesAsync();
                return customerDtos;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<string> Delete(long id)
        {
            var customer = await _context.Customers.FindAsync(id);
            try
            {
                if (customer != null)
                {
                    _context.Remove(customer);
                    _context.SaveChanges();
                }
                return "Deleted Success!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private List<Customer> Filter(CustomerFilterDto dto, int pageIndex, int pageSize)
        {
            var query = _context.Customers.AsQueryable();
            if (dto.Id.HasValue)
            {
                query = query.Where(entity => entity.Id == dto.Id);
            }
            if (!string.IsNullOrWhiteSpace(dto.CustomerNo))
            {
                query = query.Where(entity => entity.CustomerNo == dto.CustomerNo);
            }
            if (!string.IsNullOrWhiteSpace(dto.CustomerTaxNo))
            {
                query = query.Where(entity => entity.CustomerTaxNo == dto.CustomerTaxNo);
            }
            if (dto.StatusId.HasValue)
            {
                query = query.Where(entity => entity.StatusId == dto.StatusId);
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
