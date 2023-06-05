using Microsoft.AspNetCore.Mvc;
using NetCore_Project.DTO;
using NetCore_Project.DTO.DataDTO;
using NetCore_Project.DTO.FilterDTO;
using NetCore_Project.Models;
using NetCore_Project.Services;

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
            return 0;
        }

        [HttpGet]
        public CustomerDto Get(long id)
        {
            var customer = _customerService.Get(id);
            var customerDto = ConvertDtoToEntity.ConvertToDto<Customer, CustomerDto>(customer);
            return customerDto;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerDto dto)
        {
            var customerEntity = ConvertDtoToEntity.ConvertToEntity<CustomerDto, Customer>(dto);
            var (rsCustomer, errors) = await _customerService.Create(customerEntity);
            if (errors != null)
            {
                return BadRequest(errors);
            }

            return Ok(rsCustomer);
        }
        [HttpPut]
        public async Task<IActionResult> Update(long id, CustomerDto dto)
        {
            var customerEntity = ConvertDtoToEntity.ConvertToEntity<CustomerDto, Customer>(dto);
            var (rs, errors) = await _customerService.Update(id, customerEntity);

            if (errors != null)
            {
                return BadRequest(errors);
            }

            return Ok(rs);
        }
        [HttpDelete]
        public async Task<string> Delete(long id)
        {
            var rs = await _customerService.Delete(id);
            return rs;
        }
    }
}
