using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCore_Project.DTO.Customer;
using NetCore_Project.IServices;
using NetCore_Project.Models;
using Newtonsoft.Json;
using System.Net.NetworkInformation;

namespace NetCore_Project.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ExampleDbContext _context;
        public CustomerService(ExampleDbContext context)
        {
            _context = context;
        }
        public List<CustomerDto> GetListCustomer(CustomerFilterDto dto)
        {
            List<CustomerDto> listCustomer= new();
            listCustomer = Filter(dto);
            return listCustomer;
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

        private List<CustomerDto> Filter(CustomerFilterDto dto)
        {
            var query = _context.Customers.AsQueryable();
            if (dto.Id != 0)
            {
                query = query.Where(entity => entity.Id == dto.Id);
            }
            if (!string.IsNullOrEmpty(dto.CustomerNo))
            {
                query = query.Where(entity => entity.CustomerNo == dto.CustomerNo);
            }
            if (!string.IsNullOrEmpty(dto.CustomerTaxNo))
            {
                query = query.Where(entity => entity.CustomerTaxNo == dto.CustomerTaxNo);
            }
            if (dto.StatusId != 0)
            {
                query = query.Where(entity => entity.StatusId == dto.StatusId);
            }

            var entities = query.ToList();
            var json = JsonConvert.SerializeObject(entities);
            var res = JsonConvert.DeserializeObject<List<CustomerDto>>(json);
            return res;

        }
    }
}
