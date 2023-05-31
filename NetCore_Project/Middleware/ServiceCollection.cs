using NetCore_Project.IServices;
using NetCore_Project.Services;

namespace NetCore_Project.Middleware
{
    public static class ServiceCollection
    {
        public static void RegisterIoCs(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
        }
    }
}
