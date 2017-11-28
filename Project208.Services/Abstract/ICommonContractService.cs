using Project208.Services.DTOs.ContractsInfoDTOs;
using Project208.Services.DTOs.CustomerDTOs;
using Project208.Services.DTOs.SearchResultDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project208.Services.Abstract
{
    public interface ICommonContractService
    {
        Task<IEnumerable<ContractsInfoByLocationDTO>> GetDailyInfoAsync();
        Task<IEnumerable<ContractsInfoByLocationDTO>> GetTotalInfoAsync();
        Task<IEnumerable<SearchResultDTO>> GetContractsByFilterDataAsync(int locationId, int contractType, int contractStatusId, bool isDaily, string searchString);
        Task<CustomerContractsDTO> GetContractsByCustomerIdAsync(int customerId);
    }
}
