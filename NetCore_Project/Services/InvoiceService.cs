using AutoMapper;
using NetCore_Project.DTO.DataDTO;
using NetCore_Project.DTO.FilterDTO;
using NetCore_Project.Models;
using Newtonsoft.Json;

namespace NetCore_Project.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly ExampleDbContext _context;
        private readonly IMapper _mapper;
        public InvoiceService(ExampleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<InvoiceDto> GetInvoiceById(long id)
        {
            try
            {
                var invoices = await _context.Invoices.FindAsync(id);
                InvoiceDto invoiceDtos = _mapper.Map<InvoiceDto>(invoices);
                var details = GetInvoiceDetails(invoices.MasterId);
                invoiceDtos.InvoiceDetails = details;

                return invoiceDtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<InvoiceDetailDto> GetInvoiceDetails(Guid? masterId)
        {
            var invoiceDetailDtos = _context.InvoiceDetails.Where(x => x.MasterId == masterId).ToList();
            return _mapper.Map<List<InvoiceDetailDto>>(invoiceDetailDtos); ;
        }
        public PagedResultDto<InvoiceDto> GetListInvoice(InvoiceFilterDto dto, int pageIndex, int pageSize)
        {
            var listInvoices = Filter(dto, pageIndex, pageSize);
            List<InvoiceDto> invoiceDtos = _mapper.Map<List<InvoiceDto>>(listInvoices);
            PagedResultDto<InvoiceDto> pagedResult = new PagedResultDto<InvoiceDto>(pageIndex, pageSize, listInvoices.Count(), invoiceDtos);
            return pagedResult;
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

        private List<Invoice> Filter(InvoiceFilterDto dto, int pageIndex, int pageSize)
        {
            var query = _context.Invoices.AsQueryable();
            if (dto.Id.HasValue)
            {
                query = query.Where(entity => entity.Id == dto.Id);
            }
            if (dto.StatusId.HasValue)
            {
                query = query.Where(entity => entity.StatusId == dto.StatusId);
            }
            if (!string.IsNullOrWhiteSpace(dto.InvoiceNo))
            {
                query = query.Where(entity => entity.InvoiceNo == dto.InvoiceNo);
            }
            if (pageIndex >= 1)
            {
                query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            var entities = query.ToList();
            return entities;
        }
    }
}
