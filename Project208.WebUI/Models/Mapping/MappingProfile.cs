using AutoMapper;
using Project208.Services.DTOs.CustomerDTOs;

namespace Project208.WebUI.Models.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCustomerViewModel, CustomerDTO>();
            CreateMap<CustomerDetailViewModel, CustomerDTO>();
        }
    }
}
