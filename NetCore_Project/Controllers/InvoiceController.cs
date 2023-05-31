using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore_Project.DTO.Invoice;
using NetCore_Project.DTO.Products;
using NetCore_Project.IServices;

namespace NetCore_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private IInvoiceService _invoiceService;
        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        //[HttpGet]
        //public IActionResult Count()
        //{
        //    return null;
        //}
        //[HttpGet]
        //public async Task<List<InvoiceDto>> List(FilterDto dto)
        //{
        //    return null;
        //}

        //[HttpGet]
        //public IQueryable<InvoiceDto> Get(long id)
        //{
        //    return null;
        //}

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
