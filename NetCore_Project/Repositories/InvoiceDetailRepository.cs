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
        public InvoiceDetail GetByGuidId(Guid id)
        {
            //return _dbSet.Find(id)!;
            return _dbSet.FirstOrDefault(e => e.MasterId == id)!;

        }

        //public async List<InvoiceDetail> GetListByIdsAsync(Guid ids)
        //{
        //    //var invoiceDetail = await _dbSet.Where(x => x.MasterId == ids).ToListAsync();
        //    //return invoiceDetail;
        //    return null;
        //}

        public async Task<IEnumerable<InvoiceDetail>> GetEntitiesToDelete(Guid ids)
        {
            return await _dbSet.Where(e => e.MasterId == ids).ToListAsync();
        }
    }
}
