using AutoMapper;
using NetCore_Project.DTO.Customer;
using NetCore_Project.DTO.Invoice;
using NetCore_Project.DTO.Invoice.InvoiceDetails;
using NetCore_Project.DTO.Products;
using NetCore_Project.Models;

namespace NetCore_Project.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<CustomerDto, Customer>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Invoice, InvoiceDto>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<InvoiceDto, Invoice>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Product, ProductDto>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<ProductDto, Product>().ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<InvoiceDetail, InvoiceDetailDto>().ReverseMap();
            CreateMap<InvoiceDetailDto, InvoiceDetail>().ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
