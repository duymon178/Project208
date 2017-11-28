using Project208.Domain.Abstract;
using Project208.Services.Abstract;
using System.Collections.Generic;
using Project208.Services.DTOs;
using AutoMapper;
using Project208.Domain.Entities;
using System.Threading.Tasks;
using Project208.Services.DTOs.SearchResultDTOs;

namespace Project208.Services.Concrete
{
    public class T1ContractService : IT1ContractService
    {
        private readonly IT1ContractRepository t1Repository;
        private readonly IMapper mapper;

        public T1ContractService(IT1ContractRepository t1RepoParam, IMapper mapperParam)
        {
            t1Repository = t1RepoParam;
            mapper = mapperParam;
        }

        public async Task<IEnumerable<T1SearchResultDTO>> GetContractsByCustomerIdAsync(int customerId)
        {
            IEnumerable<T1SearchResultDTO> contractsDTO;
            var contracts = await t1Repository.GetContractsByCustomerIdAsync(customerId);

            contractsDTO = mapper.Map<IEnumerable<T1Contract>, IEnumerable<T1SearchResultDTO>>(contracts);
            return contractsDTO;
        }

        public async Task<IEnumerable<T1SearchResultDTO>> GetContractsByFilterDataAsync(int locationId, int contractStatusId, bool isDaily, string searchString)
        {
            IEnumerable<T1SearchResultDTO> contractsDTO;
            var contracts = await t1Repository.GetContractsByFilterDataAsync(locationId, contractStatusId, isDaily, searchString);

            contractsDTO = mapper.Map<IEnumerable<T1Contract>, IEnumerable<T1SearchResultDTO>>(contracts);
            return contractsDTO;
        }

        public async Task<int> GetDailyPayingContractsCountByLocationIdAsync(int locationId)
            => await t1Repository.GetDailyPayingContractsCountByLocationIdAsync(locationId);

        public async Task<int> GetDailySlowlyContractsCountByLocationIdAsync(int locationId)
            => await t1Repository.GetDailySlowlyContractsCountByLocationIdAsync(locationId);

        public async Task<int> GetPayingContractsCountByLocationIdAsync(int locationId)
            => await t1Repository.GetPayingContractsCountByLocationIdAsync(locationId);

        public async Task<int> GetSlowlyContractsCountByLocationIdAsync(int locationId)
            => await t1Repository.GetSlowlyContractsCountByLocationIdAsync(locationId);

        public async Task<int> GetUnableContractsCountByLocationIdAsync(int locationId)
            => await t1Repository.GetUnableContractsCountByLocationIdAsync(locationId);
    }
}
