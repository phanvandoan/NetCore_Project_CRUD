using NetCore_Project.Models;

namespace NetCore_Project.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ExampleDbContext dbContext) : base(dbContext)
        {

        }
    }
}
