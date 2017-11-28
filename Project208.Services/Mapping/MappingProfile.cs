using AutoMapper;
using Project208.Domain.Entities;
using Project208.Services.DTOs.CustomerDTOs;
using Project208.Services.DTOs.SearchResultDTOs;
using Project208.Services.Mapping.ValueResolvers;

namespace Project208.Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<T1Contract, T1SearchResultDTO>()
                .ForMember(dest => dest.LocationId,     opt => opt.MapFrom(src => src.Customer.LocationId))
                .ForMember(dest => dest.ContractStatus, opt => opt.MapFrom(src => src.ContractStatus.Vnese))
                .ForMember(dest => dest.ContractInformation,      opt => opt.ResolveUsing<ContractInformationResolver>())
                .ForMember(dest => dest.TotalUnpaidDays,          opt => opt.ResolveUsing<TotalUnpaidDaysResolver>())
                .ForMember(dest => dest.TotalPaidDays,            opt => opt.ResolveUsing<TotalPaidDaysResolver>())
                .ForMember(dest => dest.FormattedTotalUnpaidDays, opt => opt.ResolveUsing<FormattedTotalUnpaidDaysResolver>())
                .ForMember(dest => dest.FormattedTotalPaidDays,   opt => opt.ResolveUsing<FormattedTotalPaidDaysResolver>());

            CreateMap<T2Contract, T2SearchResultDTO>()
                .ForMember(dest => dest.LocationId,     opt => opt.MapFrom(src => src.Customer.LocationId))
                .ForMember(dest => dest.ContractStatus, opt => opt.MapFrom(src => src.ContractStatus.Vnese))
                .ForMember(dest => dest.Amount,            opt => opt.ResolveUsing<AmountResolver>())
                .ForMember(dest => dest.PeriodInformation, opt => opt.ResolveUsing<PeriodInformationResolver>());

            CreateMap<Customer, CustomerDTO>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CustomerAddress, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.CustomerNote, opt => opt.MapFrom(src => src.Note))
                .ForMember(dest => dest.CustomerPhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ReverseMap();
        }
    }
}
