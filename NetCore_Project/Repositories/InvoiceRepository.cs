using NetCore_Project.Models;

namespace NetCore_Project.Repositories
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(ExampleDbContext dbContext) : base(dbContext)
        {

        }
    }
}
