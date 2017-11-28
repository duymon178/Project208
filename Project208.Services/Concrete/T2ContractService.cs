using Project208.Domain.Abstract;
using Project208.Services.Abstract;
using System.Collections.Generic;
using Project208.Services.DTOs;
using Project208.Domain.Entities;
using AutoMapper;
using System.Threading.Tasks;
using Project208.Services.DTOs.SearchResultDTOs;

namespace Project208.Services.Concrete
{
    public class T2ContractService : IT2ContractService
    {
        private IT2ContractRepository t2Repository;
        private IMapper mapper;

        public T2ContractService(IT2ContractRepository t2RepoParam, IMapper mapperParam)
        {
            t2Repository = t2RepoParam;
            mapper = mapperParam;
        }

        public async Task<IEnumerable<T2SearchResultDTO>> GetContractsByCustomerIdAsync(int customerId)
        {
            IEnumerable<T2SearchResultDTO> contractsDTO;
            var contracts = await t2Repository.GetContractsByCustomerIdAsync(customerId);

            contractsDTO = mapper.Map<IEnumerable<T2Contract>, IEnumerable<T2SearchResultDTO>>(contracts);
            return contractsDTO;
        }

        public async Task<IEnumerable<T2SearchResultDTO>> GetContractsByFilterDataAsync(int locationId, int contractStatusId, bool isDaily, string searchString)
        {
            IEnumerable<T2SearchResultDTO> contractsDTO;
            var contracts = await t2Repository.GetContractsByFilterDataAsync(locationId, contractStatusId, isDaily, searchString);

            contractsDTO = mapper.Map<IEnumerable<T2Contract>, IEnumerable<T2SearchResultDTO>>(contracts);
            return contractsDTO;
        }

        public async Task<int> GetDailyPayingContractsCountByLocationIdAsync(int locationId)
            => await t2Repository.GetDailyPayingContractsCountByLocationIdAsync(locationId);

        public async Task<int> GetDailySlowlyContractsCountByLocationIdAsync(int locationId)
            => await t2Repository.GetDailySlowlyContractsCountByLocationIdAsync(locationId);

        public async Task<int> GetPayingContractsCountByLocationIdAsync(int locationId)
            => await t2Repository.GetPayingContractsCountByLocationIdAsync(locationId);

        public async Task<int> GetSlowlyContractsCountByLocationIdAsync(int locationId)
            => await t2Repository.GetSlowlyContractsCountByLocationIdAsync(locationId);

        public async Task<int> GetUnableContractsCountByLocationIdAsync(int locationId)
            => await t2Repository.GetUnableContractsCountByLocationIdAsync(locationId);
    }
}
