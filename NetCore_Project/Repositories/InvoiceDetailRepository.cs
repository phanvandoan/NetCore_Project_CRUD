using HandlebarsDotNet;
using Microsoft.EntityFrameworkCore;
using Nest;
using NetCore_Project.DTO.DataDTO;
using NetCore_Project.Models;
using System.Linq;
using static StackExchange.Redis.Role;

namespace NetCore_Project.Repositories
{
    public class InvoiceDetailRepository : GenericRepository<InvoiceDetail>, IInvoiceDetailRepository
    {

        public InvoiceDetailRepository(ExampleDbContext dbContext) : base(dbContext)
        {
        }
        //public InvoiceDetail GetByGuidId(Guid id)
        //{
        //    return _dbSet.FirstOrDefault(e => e.MasterId == id)!;

        //}

        public async Task<List<InvoiceDetail>> GetListByIdsAsync(Guid ids)
        {
            var invoiceDetail = await _dbSet.Where(x => x.MasterId == ids).ToListAsync();
            return invoiceDetail;
        }
        public void DeleteMany(IEnumerable<long> ids)
        {
            var entitiesToDelete = _context.Set<InvoiceDetail>().Where(e => ids.Contains(e.Id));
            _context.Set<InvoiceDetail>().RemoveRange(entitiesToDelete);
        }

    }
}
