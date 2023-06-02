using Microsoft.AspNetCore.Http;
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
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpPost]
        public async Task<InvoiceDto> Create(InvoiceDto dto)
        {
            var master = ConvertDtoToEntity.ConvertToEntity<InvoiceDto, Invoice>(dto);
            var detail = ConvertDtoToEntity.ConvertListDtoToListEntity<InvoiceDetailDto, InvoiceDetail>(dto.InvoiceDetails.ToList());
            var rsInvoice = await _invoiceService.Create(master, detail);
            var invoiceDto = ConvertDtoToEntity.ConvertToDto<Invoice, InvoiceDto>(rsInvoice);
            return invoiceDto;
        }
        //private IInvoiceService _invoiceService;
        //public InvoiceController(IInvoiceService invoiceService)
        //{
        //    _invoiceService = invoiceService;
        //}
        //[HttpGet]
        //public PagedResultDto<InvoiceDto> List([FromQuery] InvoiceFilterDto dto, int pageIndex, int pageSize)
        //{
        //    return _invoiceService.GetListInvoice(dto, pageIndex, pageSize);
        //}

        //[HttpGet]
        //public async Task<InvoiceDto> Get(long id)
        //{
        //    return await _invoiceService.GetInvoiceById(id);
        //}

        //[HttpPost]
        //public Task<InvoiceDto> Create(InvoiceDto dto)
        //{

        //    return _invoiceService.Create(dto);
        //}

        ////[HttpPut]
        ////public async Task<Product> Update(long id, Product dto)
        ////{
        ////    return await _productService.update(id, dto);
        ////}

        ////[HttpDelete]
        ////public async Task<string> Delete(long id)
        ////{
        ////    return await _productService.Delete(id);
        ////}
    }
}
