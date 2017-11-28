using AutoMapper;
using Project208.Domain.Entities;
using Project208.Services.DTOs.SearchResultDTOs;

namespace Project208.Services.Mapping.ValueResolvers
{
    public class TotalPaidDaysResolver : IValueResolver<T1Contract, T1SearchResultDTO, int>
    {
        public int Resolve(T1Contract source, T1SearchResultDTO destination, int destMember, ResolutionContext context)
        {
            return (source.TotalLeft % source.AmountPerDay) == 0 ? source.TotalDays - (source.TotalLeft / source.AmountPerDay) :
                                                                   source.TotalDays - (source.TotalLeft / source.AmountPerDay) - 1;
        }
    }
}
