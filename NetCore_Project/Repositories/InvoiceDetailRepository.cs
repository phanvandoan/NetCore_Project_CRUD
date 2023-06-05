using Microsoft.EntityFrameworkCore;
using NetCore_Project.Models;

namespace NetCore_Project.Repositories
{
    public class InvoiceDetailRepository : GenericRepository<InvoiceDetail>, IInvoiceDetailRepository
    {
        private readonly DbContext _context;
        public InvoiceDetailRepository(ExampleDbContext dbContext) : base(dbContext)
        {

        }
    }
}
