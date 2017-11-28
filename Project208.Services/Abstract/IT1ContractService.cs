﻿using Project208.Services.DTOs.SearchResultDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project208.Services.Abstract
{
    public interface IT1ContractService
    {
        Task<IEnumerable<T1SearchResultDTO>> GetContractsByCustomerIdAsync(int customerId);
        Task<IEnumerable<T1SearchResultDTO>> GetContractsByFilterDataAsync(int locationId, int contractStatusId, bool isDaily, string searchString);
        Task<int> GetDailyPayingContractsCountByLocationIdAsync(int locationId);
        Task<int> GetDailySlowlyContractsCountByLocationIdAsync(int locationId);
        Task<int> GetPayingContractsCountByLocationIdAsync(int locationId);
        Task<int> GetSlowlyContractsCountByLocationIdAsync(int locationId);
        Task<int> GetUnableContractsCountByLocationIdAsync(int locationId);
    }
}
