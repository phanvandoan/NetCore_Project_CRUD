using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        //private ICustomerService _customerService;
        //public CustomerController(ICustomerService customerService)
        //{
        //    _customerService = customerService;
        //}
        //[HttpGet]
        //public IActionResult Count()
        //{
        //    return null;
        //}
        //[HttpGet]
        //public PagedResultDto<CustomerDto> List([FromQuery] CustomerFilterDto dto, int pageIndex, int pageSize)
        //{
        //    return _customerService.GetListCustomer(dto, pageIndex, pageSize);
        //}

        //[HttpGet]
        //public async Task<CustomerDto> Get(long id)
        //{

        //    return await _customerService.GetCustomerById(id);
        //}

        //[HttpPost]
        //public async Task<CustomerDto> Create(CustomerDto dto)
        //{

        //    return await _customerService.Create(dto);
        //}

        //[HttpPut]
        //public async Task<Customer> Update(long id, CustomerDto dto)
        //{
        //    return await _customerService.update(id, dto);
        //}

        //[HttpDelete]
        //public async Task<string> Delete(long id)
        //{
        //    return await _customerService.Delete(id);
        //}
    }
}
