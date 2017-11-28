using AutoMapper;
using Project208.Domain.Entities;
using Project208.Services.DTOs.SearchResultDTOs;

namespace Project208.Services.Mapping.ValueResolvers
{
    public class FormattedTotalPaidDaysResolver : IValueResolver<T1Contract, T1SearchResultDTO, string>
    {
        public string Resolve(T1Contract source, T1SearchResultDTO destination, string destMember, ResolutionContext context)
        {
            return (source.TotalLeft % source.AmountPerDay) == 0 ? $"{source.TotalDays - (source.TotalLeft / source.AmountPerDay)}b" :
                                                                   $"{source.TotalDays - (source.TotalLeft / source.AmountPerDay) - 1}b + {source.AmountPerDay - (source.TotalLeft % source.AmountPerDay)}k";
        }
    }
}
