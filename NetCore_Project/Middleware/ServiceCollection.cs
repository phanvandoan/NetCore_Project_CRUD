using FluentValidation;
using Nest;
using NetCore_Project.DTO.DataDTO;
using NetCore_Project.Models;
using NetCore_Project.Repositories;
using NetCore_Project.Services;
using NetCore_Project.Services.Valid;

namespace NetCore_Project.Middleware
{
    public static class ServiceCollection
    {
        public static void RegisterIoCs(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IInvoiceService, InvoiceService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IInvoiceDetailRepository, InvoiceDetailRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddTransient<IValidator<Customer>, CustomerFieldValidator>();
            services.AddTransient<IValidator<Product>, ProductFieldValidator>();
            services.AddTransient<IValidator<CreateUpdateInvoiceDto>, InvoiceFieldValidator>();


        }
    }
}
