using Project208.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project208.Domain.Abstract
{
    public interface ICustomerRepository
    {
        Task<Customer> UpdateCustomerAsync(Customer customer);
        Task<Customer> DeleteCustomerAsync(int customerId);
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task<IEnumerable<Customer>> GetCustomersByFilterDataAsync(int locationId, string searchString);
        Task<int> GetCustomersCountByLocationIdAsync(int locationId);
        Task<Customer> GetCustomerByIdAsync(int customerId);
    }
}
