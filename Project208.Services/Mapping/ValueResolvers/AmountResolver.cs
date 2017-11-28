using AutoMapper;
using Project208.Domain.Entities;
using Project208.Services.DTOs.SearchResultDTOs;

namespace Project208.Services.Mapping.ValueResolvers
{
    public class AmountResolver : IValueResolver<T2Contract, T2SearchResultDTO, int>
    {
        public int Resolve(T2Contract source, T2SearchResultDTO destination, int destMember, ResolutionContext context)
        {
            return source.Amount / 1000;
        }
    }
}
