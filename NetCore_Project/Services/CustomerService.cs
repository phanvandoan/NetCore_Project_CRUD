using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                CustomerDto res = new();
                var customer = await _context.Customers.FindAsync(id);
                var json = JsonConvert.SerializeObject(customer);
                res = JsonConvert.DeserializeObject<CustomerDto>(json);
                return res;
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
                CustomerDto res = new();
                var customers = new Customer()
                {
                    StatusId = dto.StatusId,
                    RowId = Guid.NewGuid(),
                    Used = dto.Used,
                    CreatedAt = dto.CreatedAt,
                    UpdatedAt = dto.UpdatedAt,
                    DeletedAt = dto.DeletedAt,
                    CustomerNo = dto.CustomerNo,
                    CustomerFirstName = dto.CustomerFirstName,
                    CustomerLastName = dto.CustomerLastName,
                    CustomerCompany = dto.CustomerCompany,
                    CustomerAddress = dto.CustomerAddress,
                    CustomerDistrict = dto.CustomerDistrict,
                    CustomerCity = dto.CustomerCity,
                    CustomerAccountNo = dto.CustomerAccountNo,
                    CustomerTaxNo = dto.CustomerTaxNo,
                };

                var json = JsonConvert.SerializeObject(customers);
                res = JsonConvert.DeserializeObject<CustomerDto>(json);

                await _context.Customers.AddAsync(customers);
                await _context.SaveChangesAsync();
                return res;
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
                if (customer != null)
                {
                    customer.StatusId = dto.StatusId;
                    customer.RowId = dto.RowId;
                    customer.Used = dto.Used;
                    customer.CreatedAt = dto.CreatedAt;
                    customer.UpdatedAt = dto.UpdatedAt;
                    customer.DeletedAt = dto.DeletedAt;
                    customer.CustomerNo = dto.CustomerNo;
                    customer.CustomerFirstName = dto.CustomerFirstName;
                    customer.CustomerLastName = dto.CustomerLastName;
                    customer.CustomerCompany = dto.CustomerCompany;
                    customer.CustomerAddress = dto.CustomerAddress;
                    customer.CustomerDistrict = dto.CustomerDistrict;
                    customer.CustomerCity = dto.CustomerCity;
                    customer.CustomerAccountNo = dto.CustomerAccountNo;
                    customer.CustomerTaxNo = dto.CustomerTaxNo;

                    await _context.SaveChangesAsync();
                }
                else
                {
                    return null;
                }
                return customer;
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

        //private List<Customer> Filter(CustomerFilterDto dto, int pageIndex, int pageSize)
        //{
        //    var query = _context.Customers.AsQueryable();
        //    if (dto.Id.HasValue)
        //    {
        //        query = query.Where(entity => entity.Id == dto.Id);
        //    }
        //    if (!string.IsNullOrWhiteSpace(dto.CustomerNo))
        //    {
        //        query = query.Where(entity => entity.CustomerNo == dto.CustomerNo);
        //    }
        //    if (!string.IsNullOrWhiteSpace(dto.CustomerTaxNo))
        //    {
        //        query = query.Where(entity => entity.CustomerTaxNo == dto.CustomerTaxNo);
        //    }
        //    if (dto.StatusId.HasValue)
        //    {
        //        query = query.Where(entity => entity.StatusId == dto.StatusId);
        //    }
        //    var entities = query.ToList().Skip((pageIndex - 1) * pageSize).Take(pageSize); 
        //    return entities;
        //}

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
            var entities=query.ToList();
            return entities;
        }

    }
}
