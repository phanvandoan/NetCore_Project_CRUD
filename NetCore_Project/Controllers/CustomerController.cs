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
            int count = await _customerService.Count(filterDto);
            return count;
        }
        [HttpGet]
        public List<CustomerDto> List([FromQuery] CustomerFilterDto filterDto)
        {
            var customer = _customerService.List(filterDto);
            List<CustomerDto> rs = MapEntitiesToDTOs(customer);
            return rs;
        }
        [HttpGet]
        public CustomerDto Get(long id)
        {
            var customer = _customerService.Get(id);
            CustomerDto customerDto = new CustomerDto(customer);
            return customerDto;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CustomerDto dto)
        {
            var customerEntity = ConvertDtoToEntity.ConvertToEntity<CustomerDto, Customer>(dto);
            var (rsCustomer, errors) = await _customerService.Create(customerEntity);
            CustomerDto customerDto = new CustomerDto(rsCustomer);
            if (errors != null)
            {
                return BadRequest(errors);
            }
            return Ok(customerDto);
        }
        [HttpPut]
        public async Task<IActionResult> Update(long id, CustomerDto dto)
        {
            var customerEntity = ConvertDtoToEntity.ConvertToEntity<CustomerDto, Customer>(dto);
            var (rs, errors) = await _customerService.Update(id, customerEntity);
            CustomerDto customerDto = new CustomerDto(rs);
            if (errors != null)
            {
                return BadRequest(errors);
            }

            return Ok(customerDto);
        }
        [HttpDelete]
        public async Task<string> Delete(long id)
        {
            var rs = await _customerService.Delete(id);
            return rs;
        }
        private List<CustomerDto> MapEntitiesToDTOs(List<Customer> entities)
        {
            List<CustomerDto> dtos = entities.Select(entity => new CustomerDto(entity)).ToList();
            return dtos;
        }
    }
}
