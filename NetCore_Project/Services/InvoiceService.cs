using Nest;
using NetCore_Project.DTO.Customer;
using NetCore_Project.DTO.Invoice;
using NetCore_Project.DTO.Invoice.InvoiceDetails;
using NetCore_Project.IServices;
using NetCore_Project.Models;
using Newtonsoft.Json;

namespace NetCore_Project.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly ExampleDbContext _context;
        public InvoiceService(ExampleDbContext context)
        {
            _context = context;
        }

        public async Task<InvoiceDto> Create(InvoiceDto dto)
        {
            try
            {
                Guid masterId = Guid.NewGuid();
                var master = await CreateInvoice(dto, masterId);
                var details = await CreateInvoiceDetail(dto.InvoiceDetails.ToList(), masterId);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return null;
        }

        private async Task<InvoiceDto> CreateInvoice(InvoiceDto dto, Guid masterId)
        {
            try
            {
                InvoiceDto res = new();
                var invoices = new Invoice()
                {
                    StatusId = dto.StatusId,
                    RowId = Guid.NewGuid(),
                    Used = dto.Used,
                    CreatedAt = dto.CreatedAt,
                    UpdatedAt = dto.UpdatedAt,
                    DeletedAt = dto.DeletedAt,
                    InvoiceNo = dto.InvoiceNo,
                    MasterId = masterId,
                    InvoiceDate = dto.InvoiceDate,
                    PaymentMethod = dto.PaymentMethod,
                    Vat = dto.Vat
                };

                var json = JsonConvert.SerializeObject(invoices);
                res = JsonConvert.DeserializeObject<InvoiceDto>(json);
                await _context.Invoices.AddAsync(invoices);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task<List<InvoiceDetailDto>> CreateInvoiceDetail(List<InvoiceDetailDto> dto, Guid masterId)
        {
            try
            {
                List<InvoiceDetailDto> listInvoiceDetail = new();
                foreach (var item in dto)
                {
                    InvoiceDetailDto res = new();
                    var invoiceDetails = new InvoiceDetail()
                    {
                        StatusId = item.StatusId,
                        RowId = Guid.NewGuid(),
                        Used = item.Used,
                        CreatedAt = item.CreatedAt,
                        UpdatedAt = item.UpdatedAt,
                        DeletedAt = item.DeletedAt,
                        InvoiceDetailsNo = item.InvoiceDetailsNo,
                        MasterId = masterId,
                        SequenceNo = item.SequenceNo,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice,
                    };
                    var json = JsonConvert.SerializeObject(invoiceDetails);
                    res = JsonConvert.DeserializeObject<InvoiceDetailDto>(json);
                    listInvoiceDetail.Add(res);
                }
                var json1 = JsonConvert.SerializeObject(listInvoiceDetail);
                var res1 = JsonConvert.DeserializeObject<List<InvoiceDetail>>(json1);

                await _context.InvoiceDetails.AddRangeAsync(res1);
                return listInvoiceDetail;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
