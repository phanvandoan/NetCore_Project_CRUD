using NetCore_Project.Models;

namespace NetCore_Project.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ExampleDbContext dbContext) : base(dbContext)
        {

        }
    }
}
