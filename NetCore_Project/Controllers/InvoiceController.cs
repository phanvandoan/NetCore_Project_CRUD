using Microsoft.AspNetCore.Mvc;
using NetCore_Project.DTO;
using NetCore_Project.DTO.DataDTO;
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
        [HttpGet]
        public Task<CreateUpdateInvoiceDto> Get(long id)
        {
            var invoice = _invoiceService.Get(id);
            return invoice;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateUpdateInvoiceDto dto)
        {
            var master = ConvertDtoToEntity.ConvertToEntity<CreateUpdateInvoiceDto, Invoice>(dto);
            var detail = ConvertDtoToEntity.ConvertListDtoToListEntity<InvoiceDetail, InvoiceDetail>(dto.InvoiceDetails.ToList());
            var (rsInvoice, errors) = await _invoiceService.Create(dto, detail);

            if (errors != null)
            {
                return BadRequest(errors);
            }

            return Ok(rsInvoice);
        }
        [HttpPut]
        public async Task<IActionResult> Update(CreateUpdateInvoiceDto dto, long id)
        {
            var (rsInvoice, errors) = await _invoiceService.Update(dto, id);
            if (errors != null)
            {
                return BadRequest(errors);
            }
            return Ok(rsInvoice);
        }
        [HttpDelete]
        public async Task<string> Delete(long id)
        {
            var rs = await _invoiceService.Delete(id);
            return rs;
        }
    }
}
