using AutoMapper;
using Project208.Domain.Entities;
using Project208.Services.DTOs.SearchResultDTOs;

namespace Project208.Services.Mapping.ValueResolvers
{
    public class PeriodInformationResolver : IValueResolver<T2Contract, T2SearchResultDTO, string>
    {
        public string Resolve(T2Contract source, T2SearchResultDTO destination, string destMember, ResolutionContext context)
        {
            return $"{source.AmountPerPeriod}k/{source.Period}";
        }
    }
}
