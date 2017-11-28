using Project208.Domain.Abstract;
using System;
using System.Collections.Generic;
using Project208.Domain.Entities;
using System.Linq;
using Project208.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Project208.Domain.Concrete
{
    public class EFT1ContractRepository : IT1ContractRepository
    {
        private EFDbContext context;

        public EFT1ContractRepository(EFDbContext ctx)
        {
            context = ctx;
        }

        public async Task<IEnumerable<T1Contract>> GetContractsByCustomerIdAsync(int CustomerId)
        {
            var contracts = context.T1Contracts.Include(c => c.ContractStatus).Where(c => c.CustomerId == CustomerId);
            return await contracts.OrderBy(c => c.ContractStatusId).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<T1Contract>> GetContractsByFilterDataAsync(int LocationId, int ContractStatusId, bool isDaily, string searchString)
        {
            var contracts = context.T1Contracts
                                   .Include(c => c.Customer)
                                   .Include(c => c.ContractStatus)
                                   .Where(c => c.Customer.LocationId == LocationId &&
                                               c.ContractStatusId == ContractStatusId);

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                contracts = contracts.Where(c => c.Customer.Name.StartsWith(searchString));
            }

            if (isDaily && ContractStatusId == (int)ContractStatusEnum.Paying)
            {
                contracts = contracts.Where(c => c.T1PaymentDetails.Any(p => p.NeedToPayDate == DateTime.Today
                                                                          && p.Amount == 0
                                                                          && p.ActualPayDate == null));
            }

            return await contracts.OrderBy(c => c.Customer.Name).AsNoTracking().ToListAsync();
        }

        public async Task<int> GetDailyPayingContractsCountByLocationIdAsync(int LocationId)
            => await context.T1Contracts.Where(c => c.Customer.LocationId == LocationId
                                                 && c.ContractStatusId == (int)ContractStatusEnum.Paying
                                                 && c.T1PaymentDetails.Any(p => p.NeedToPayDate == DateTime.Today
                                                                             && p.Amount == 0
                                                                             && p.ActualPayDate == null))
                                        .CountAsync();

        public async Task<int> GetDailySlowlyContractsCountByLocationIdAsync(int LocationId)
            => await context.T1Contracts.Where(c => c.Customer.LocationId == LocationId
                                                 && c.ContractStatusId == (int)ContractStatusEnum.SlowlyReturn
                                                 && (c.LastReturnDate < DateTime.Today || c.LastReturnDate == null))
                                         .CountAsync();

        public async Task<int> GetPayingContractsCountByLocationIdAsync(int LocationId)
            => await context.T1Contracts.Where(c => c.Customer.LocationId == LocationId
                                                 && c.ContractStatusId == (int)ContractStatusEnum.Paying)
                                        .CountAsync();

        public async Task<int> GetSlowlyContractsCountByLocationIdAsync(int LocationId)
            => await context.T1Contracts.Where(c => c.Customer.LocationId == LocationId
                                                 && c.ContractStatusId == (int)ContractStatusEnum.SlowlyReturn)
                                        .CountAsync();

        public async Task<int> GetUnableContractsCountByLocationIdAsync(int LocationId)
            => await context.T1Contracts.Where(c => c.Customer.LocationId == LocationId
                                                 && c.ContractStatusId == (int)ContractStatusEnum.UnableToPay)
                                         .CountAsync();
    }
}
