using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore_Project.DTO.Customer;
using NetCore_Project.DTO.Invoice;
using NetCore_Project.DTO.PagedResult;
using NetCore_Project.DTO.Products;
using NetCore_Project.IServices;
using NetCore_Project.Services;

namespace NetCore_Project.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private IInvoiceService _invoiceService;
        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }
        [HttpGet]
        public PagedResultDto<InvoiceDto> List([FromQuery] InvoiceFilterDto dto, int pageIndex, int pageSize)
        {
            return _invoiceService.GetListInvoice(dto, pageIndex, pageSize);
        }

        [HttpGet]
        public async Task<InvoiceDto> Get(long id)
        {
            return await _invoiceService.GetInvoiceById(id);
        }

        [HttpPost]
        public Task<InvoiceDto> Create(InvoiceDto dto)
        {

            return _invoiceService.Create(dto);
        }

        //[HttpPut]
        //public async Task<Product> Update(long id, Product dto)
        //{
        //    return await _productService.update(id, dto);
        //}

        //[HttpDelete]
        //public async Task<string> Delete(long id)
        //{
        //    return await _productService.Delete(id);
        //}
    }
}
