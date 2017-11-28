using Project208.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project208.Domain.Abstract
{
    public interface IT2ContractRepository
    {
        Task<IEnumerable<T2Contract>> GetContractsByCustomerIdAsync(int customerId);
        Task<IEnumerable<T2Contract>> GetContractsByFilterDataAsync(int locationId, int contractStatusId, bool isDaily, string searchString);
        Task<int> GetDailyPayingContractsCountByLocationIdAsync(int locationId);
        Task<int> GetDailySlowlyContractsCountByLocationIdAsync(int locationId);
        Task<int> GetPayingContractsCountByLocationIdAsync(int locationId);
        Task<int> GetSlowlyContractsCountByLocationIdAsync(int locationId);
        Task<int> GetUnableContractsCountByLocationIdAsync(int locationId);
    }
}
