using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore_Project.DTO.Customer;
using NetCore_Project.DTO.Products;
using NetCore_Project.IServices;
using NetCore_Project.Models;
using NetCore_Project.Services;

namespace NetCore_Project.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public IActionResult Count()
        {
            return null;
        }
        [HttpGet]
        public List<CustomerDto> List([FromRoute] CustomerFilterDto dto)
        {
            return _customerService.GetListCustomer(dto);
        }

        [HttpGet]
        public async Task<CustomerDto> Get(long id)
        {

            return await _customerService.GetCustomerById(id);
        }

        [HttpPost]
        public async Task<CustomerDto> Create(CustomerDto dto)
        {

            return await _customerService.Create(dto);
        }

        [HttpPut]
        public async Task<Customer> Update(long id, CustomerDto dto)
        {
            return await _customerService.update(id, dto);
        }

        [HttpDelete]
        public async Task<string> Delete(long id)
        {
            return await _customerService.Delete(id);
        }
    }
}
