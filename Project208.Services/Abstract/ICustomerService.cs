using Project208.Services.DTOs.CustomerDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project208.Services.Abstract
{
    public interface ICustomerService
    {
        Task<CustomerDTO> UpdateCustomerAsync(CustomerDTO customerDTO);
        Task<CustomerDTO> DeleteCustomerAsync(int customerId);
        Task<CustomerDTO> CreateCustomerAsync(CustomerDTO customerDTO);
        Task<IEnumerable<CustomerDTO>> GetCustomersByFilterDataAsync(int locationId, string searchString);
        Task<IEnumerable<CustomersInfoDTO>> GetCustomersInfoAsync();
        Task<CustomerDTO> GetCustomerByIdAsync(int customerId);
    }
}
