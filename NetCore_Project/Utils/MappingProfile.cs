using AutoMapper;
using NetCore_Project.DTO.DataDTO;
using NetCore_Project.DTO.FilterDTO;
using NetCore_Project.Models;
using System.Linq.Expressions;

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

            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductDto, Product>().ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<InvoiceDetail, InvoiceDetailDto>().ReverseMap();
            CreateMap<InvoiceDetailDto, InvoiceDetail>().ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<ProductFilterDto, Expression<Func<Product, bool>>>().ReverseMap();

            CreateMap<ProductFilterDto, Product>();

        }
    }
}
