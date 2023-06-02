using NetCore_Project.DTO.DataDTO;
using NetCore_Project.DTO.FilterDTO;
using NetCore_Project.Models;
using System.Linq.Expressions;

namespace NetCore_Project.Services
{
    public interface IInvoiceService
    {
        Task<int> Count(Expression<Func<Invoice, bool>> filter = null);
        Invoice Get(long id);
        //PagedResultDto<ProductDto> GetListProduct(ProductFilterDto dto, int pageIndex, int pageSize);
        //Task<ProductDto> GetProductById(long id);
        Task<Invoice> Create(Invoice masterModel, List<InvoiceDetail> detailModel);
        //Task<ProductDto> update(long id, ProductDto dto);
        Task<Invoice> Update(long id, InvoiceDto dto);
        Task<string> Delete(long id);
    }
}
