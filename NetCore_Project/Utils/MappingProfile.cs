using AutoMapper;
using NetCore_Project.DTO.Customer;
using NetCore_Project.Models;

namespace NetCore_Project.Utils
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<CustomerDto, Customer>().ReverseMap();
        }
    }
}
