using AutoMapper;
using FluentValidation;
using Humanizer;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using Nest;
using NetCore_Project.DTO.DataDTO;
using NetCore_Project.DTO.FilterDTO;
using NetCore_Project.Models;
using NetCore_Project.Repositories;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;
using System.Linq.Expressions;
using static StackExchange.Redis.Role;

namespace NetCore_Project.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IInvoiceDetailRepository _invoiceDetailRepository;
        private readonly IValidator<CreateUpdateInvoiceDto> _validator;
        public InvoiceService(IUnitOfWork unitOfWork, IInvoiceDetailRepository invoiceDetailRepository, IValidator<CreateUpdateInvoiceDto> validator)
        {
            _unitOfWork = unitOfWork;
            _invoiceDetailRepository = invoiceDetailRepository;
            _validator = validator;
        }
        public async Task<int> Count(InvoiceFilterDto filter)
        {
            var invoice = new Invoice()
            {
                Id = (long)filter.Id!,
                StatusId = filter.StatusId,
                InvoiceNo = filter.InvoiceNo,
            };
            var count = _unitOfWork.Invoices.CountAll(invoice);
            return count;
        }
        public List<Invoice> List(InvoiceFilterDto filter)
        {
            var invoice = new Invoice()
            {
                Id = (long)filter.Id!,
                StatusId = filter.StatusId,
                InvoiceNo = filter.InvoiceNo,
            };
            var invoices = _unitOfWork.Invoices.List(invoice);
            return invoices;
        }









        public async Task<(CreateUpdateInvoiceDto, Dictionary<string, string>)> Create(CreateUpdateInvoiceDto masterModel, List<InvoiceDetail> detailModel)
        {
            try
            {
                Guid masterId = Guid.NewGuid();
                var master = await CreateInvoice(masterModel, masterId);
                var details = await CreateInvoiceDetail(detailModel, masterId);
                master.Item1.InvoiceDetails = details;
                var result = _unitOfWork.Save();
                return (master.Item1, null)!;
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw ex;
            }
        }
        public async Task<(CreateUpdateInvoiceDto, Dictionary<string, string>)> Update(CreateUpdateInvoiceDto dto, long id)
        {
            try
            {
                var invoice = _unitOfWork.Invoices.Get(id);
                if (invoice != null)
                {
                    var master = await UpdateInvoice(invoice, dto);
                    await DeleteInvoiceDetail(invoice.MasterId);
                    var details = await CreateInvoiceDetail(dto.InvoiceDetails, master.Item1.MasterId);
                    var result = _unitOfWork.Save();
                    return (master.Item1, null)!;
                }
                return (null, null)!;
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw ex;
            }
            

        }

        public async Task<string> Delete(long id)
        {
            string message = null;
            if (id != 0)
            {
                var invoice = _unitOfWork.Invoices.Get(id);
                if (invoice != null)
                {
                    await DeleteInvoiceDetail(invoice.MasterId);
                    _unitOfWork.Invoices.Delete(invoice);
                    var result = _unitOfWork.Save();
                    message = "Deleted success!";
                    return message;
                }
            }
            return message;
        }

        public async Task<CreateUpdateInvoiceDto> Get(long id)
        {
            if (id != null)
            {
                var invoice = _unitOfWork.Invoices.Get(id);
                var invoices = new CreateUpdateInvoiceDto()
                {
                    StatusId = invoice.StatusId,
                    RowId = invoice.RowId,
                    Used = invoice.Used,
                    CreatedAt = invoice.CreatedAt,
                    UpdatedAt = invoice.UpdatedAt,
                    DeletedAt = invoice.DeletedAt,
                    InvoiceNo = invoice.InvoiceNo,
                    MasterId = invoice.MasterId,
                    InvoiceDate = invoice.InvoiceDate,
                    PaymentMethod = invoice.PaymentMethod,
                    Vat = invoice.Vat
                };
                invoices.InvoiceDetails = await _invoiceDetailRepository.GetListByIdsAsync(invoice.MasterId);
                return invoices;
            }
            return null;
        }
        private async Task<(CreateUpdateInvoiceDto, Dictionary<string, string>)> UpdateInvoice(Invoice invoice, CreateUpdateInvoiceDto dto)
        {
            try
            {
                var validationResult = _validator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    var errors = validationResult.Errors.ToDictionary(error => error.ErrorCode, error => error.ErrorMessage);
                    return (null, errors)!;
                }
                if (invoice != null)
                {
                    invoice.StatusId = dto.StatusId;
                    invoice.Used = dto.Used;
                    invoice.UpdatedAt = dto.UpdatedAt;
                    invoice.InvoiceNo = dto.InvoiceNo;
                    invoice.InvoiceDate = dto.InvoiceDate;
                    invoice.PaymentMethod = dto.PaymentMethod;
                    invoice.Vat = dto.Vat;
                    _unitOfWork.Invoices.Update(invoice);
                };
                var cuInvoiceDto = new CreateUpdateInvoiceDto()
                {
                    StatusId = invoice.StatusId,
                    RowId = invoice.RowId,
                    Used = invoice.Used,
                    CreatedAt = invoice.CreatedAt,
                    UpdatedAt = invoice.UpdatedAt,
                    DeletedAt = invoice.DeletedAt,
                    InvoiceNo = invoice.InvoiceNo,
                    MasterId = invoice.MasterId,
                    InvoiceDate = invoice.InvoiceDate,
                    PaymentMethod = invoice.PaymentMethod,
                    Vat = dto.Vat
                };
                return (dto, null)!;
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw ex;
            }
        }
        private async Task<(CreateUpdateInvoiceDto, Dictionary<string, string>)> CreateInvoice(CreateUpdateInvoiceDto dto, Guid masterId)
        {
            try
            {
                var validationResult = _validator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    var errors = validationResult.Errors.ToDictionary(error => error.ErrorCode, error => error.ErrorMessage);
                    return (null, errors);
                }

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

                var cuInvoiceDto = new CreateUpdateInvoiceDto()
                {
                    StatusId = invoices.StatusId,
                    RowId = invoices.RowId,
                    Used = invoices.Used,
                    CreatedAt = invoices.CreatedAt,
                    UpdatedAt = invoices.UpdatedAt,
                    DeletedAt = invoices.DeletedAt,
                    InvoiceNo = invoices.InvoiceNo,
                    MasterId = masterId,
                    InvoiceDate = invoices.InvoiceDate,
                    PaymentMethod = invoices.PaymentMethod,
                    Vat = dto.Vat
                };
                var rs = await _unitOfWork.Invoices.Create(invoices);
                return (dto, null);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw ex;
            }
        }
        private async Task<List<InvoiceDetail>> CreateInvoiceDetail(List<InvoiceDetail> dto, Guid masterId)
        {
            try
            {
                List<InvoiceDetail> listInvoiceDetail = new();
                foreach (var item in dto)
                {
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
                    listInvoiceDetail.Add(invoiceDetails);
                }
                var rs = await _unitOfWork.InvoiceDetails.CreateMany(listInvoiceDetail);
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private async Task DeleteInvoiceDetail(Guid masterId)
        {
            var entitiesToDelete = await _invoiceDetailRepository.GetListByIdsAsync(masterId);
            var invoiceDetail = entitiesToDelete.Select(p => p.Id).ToList();
            var idsToDelete = entitiesToDelete.Select(p => p.Id).ToList();
            _invoiceDetailRepository.DeleteMany(idsToDelete);
        }

    }
}
