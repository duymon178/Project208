using AutoMapper;
using Project208.Domain.Entities;
using Project208.Services.DTOs.SearchResultDTOs;

namespace Project208.Services.Mapping.ValueResolvers
{
    public class ContractInformationResolver : IValueResolver<T1Contract, T1SearchResultDTO, string>
    {
        public string Resolve(T1Contract source, T1SearchResultDTO destination, string destMember, ResolutionContext context)
        {
            return $"{source.Amount / 1000}tr/{source.TotalDays}/{source.AmountPerDay}";
        }
    }
}
