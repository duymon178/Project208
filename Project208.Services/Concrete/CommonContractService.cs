using Project208.Domain.Enums;
using Project208.Services.Abstract;
using Project208.Services.DTOs;
using Project208.Services.DTOs.ContractDTOs;
using Project208.Services.DTOs.ContractsInfoDTOs;
using Project208.Services.DTOs.CustomerDTOs;
using Project208.Services.DTOs.SearchResultDTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project208.Services.Concrete
{
    public class CommonContractService : ICommonContractService
    {
        private readonly IT1ContractService t1Service;
        private readonly IT2ContractService t2Service;
        private readonly ILocationService locationService;
        private readonly ICustomerService customerService;

        public CommonContractService(IT1ContractService t1ServiceParam, IT2ContractService t2ServiceParam,
            ILocationService locationServiceParam, ICustomerService cusServiceParam)
        {
            t1Service = t1ServiceParam;
            t2Service = t2ServiceParam;
            locationService = locationServiceParam;
            customerService = cusServiceParam;
        }

        public async Task<IEnumerable<ContractsInfoByLocationDTO>> GetDailyInfoAsync()
        {
            List<ContractsInfoByLocationDTO> dailyInfoList = new List<ContractsInfoByLocationDTO>();

            for (int i = 1; i <= await locationService.LocationsCountAsync(); i++)
            {
                var location = await locationService.GetLocationByIdAsync(i);

                LocationDTO locationDTO = new LocationDTO
                {
                    LocationId   = location.LocationId,
                    LocationName = location.Name
                };

                ContractsInfoByTypeDTO t1ContractInfo = new ContractsInfoByTypeDTO
                {
                    ContractType = new T1ContractDTO(),
                    PayingContracts = await t1Service.GetDailyPayingContractsCountByLocationIdAsync(i),
                    SlowlyContracts = await t1Service.GetDailySlowlyContractsCountByLocationIdAsync(i)
                };

                ContractsInfoByTypeDTO t2ContractInfo = new ContractsInfoByTypeDTO
                {
                    ContractType = new T2ContractDTO(),
                    PayingContracts = await t2Service.GetDailyPayingContractsCountByLocationIdAsync(i),
                    SlowlyContracts = await t2Service.GetDailySlowlyContractsCountByLocationIdAsync(i)
                };

                List<ContractsInfoByTypeDTO> contractsInfo = new List<ContractsInfoByTypeDTO>
                {
                    t1ContractInfo,
                    t2ContractInfo
                };

                ContractsInfoByLocationDTO locationDailyInfo = new ContractsInfoByLocationDTO
                {
                    Location      = locationDTO,
                    ContractsInfo = contractsInfo
                };

                dailyInfoList.Add(locationDailyInfo);
            }

            return dailyInfoList;
        }

        public async Task<IEnumerable<ContractsInfoByLocationDTO>> GetTotalInfoAsync()
        {
            List<ContractsInfoByLocationDTO> totalInfoList = new List<ContractsInfoByLocationDTO>();

            for (int i = 1; i <= await locationService.LocationsCountAsync(); i++)
            {
                var location = await locationService.GetLocationByIdAsync(i);

                LocationDTO locationDTO = new LocationDTO
                {
                    LocationId   = location.LocationId,
                    LocationName = location.Name
                };

                ContractsInfoByTypeDTO t1ContractInfo = new ContractsInfoByTypeDTO
                {
                    ContractType = new T1ContractDTO(),
                    PayingContracts = await t1Service.GetPayingContractsCountByLocationIdAsync(i),
                    SlowlyContracts = await t1Service.GetSlowlyContractsCountByLocationIdAsync(i),
                    UnableContracts = await t1Service.GetUnableContractsCountByLocationIdAsync(i)
                };

                ContractsInfoByTypeDTO t2ContractInfo = new ContractsInfoByTypeDTO
                {
                    ContractType = new T2ContractDTO(),
                    PayingContracts = await t2Service.GetPayingContractsCountByLocationIdAsync(i),
                    SlowlyContracts = await t2Service.GetSlowlyContractsCountByLocationIdAsync(i),
                    UnableContracts = await t2Service.GetUnableContractsCountByLocationIdAsync(i)
                };

                List<ContractsInfoByTypeDTO> contractsInfo = new List<ContractsInfoByTypeDTO>
                {
                    t1ContractInfo,
                    t2ContractInfo
                };

                ContractsInfoByLocationDTO locationTotalInfo = new ContractsInfoByLocationDTO
                {
                    Location      = locationDTO,
                    ContractsInfo = contractsInfo
                };

                totalInfoList.Add(locationTotalInfo);
            }

            return totalInfoList;
        }

        public async Task<IEnumerable<SearchResultDTO>> GetContractsByFilterDataAsync(int locationId, int contractType, int contractStatusId, bool isDaily, string searchString)
        {
            IEnumerable<SearchResultDTO> contracts = null;

            if (await locationService.GetLocationByIdAsync(locationId) != null && Enum.IsDefined(typeof(ContractStatusEnum), contractStatusId))
            {
                if (contractType == (int)ContractTypeEnum.Type1)
                {
                    contracts = await t1Service.GetContractsByFilterDataAsync(locationId, contractStatusId, isDaily, searchString);
                }
                else
                {
                    contracts = await t2Service.GetContractsByFilterDataAsync(locationId, contractStatusId, isDaily, searchString);
                }
            }

            return contracts;
        }

        public async Task<CustomerContractsDTO> GetContractsByCustomerIdAsync(int customerId)
        {
            CustomerContractsDTO customerContracts = new CustomerContractsDTO();

            if (await customerService.GetCustomerByIdAsync(customerId) != null)
            {
                customerContracts.T1Contracts = await t1Service.GetContractsByCustomerIdAsync(customerId);
                customerContracts.T2Contracts = await t2Service.GetContractsByCustomerIdAsync(customerId);
            }

            return customerContracts;
        }
    }
}
