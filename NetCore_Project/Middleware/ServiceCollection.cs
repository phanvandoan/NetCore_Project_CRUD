using Nest;
using NetCore_Project.Models;
using NetCore_Project.Repositories;
using NetCore_Project.Services;

namespace NetCore_Project.Middleware
{
    public static class ServiceCollection
    {
        public static void RegisterIoCs(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


            //services.AddScoped<IProductService, ProductService>();
            //services.AddScoped<ICustomerService, CustomerService>();
            //services.AddScoped<IInvoiceService, InvoiceService>();
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}
