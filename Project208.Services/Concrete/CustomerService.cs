using Project208.Domain.Abstract;
using Project208.Domain.Entities;
using Project208.Services.Abstract;
using System.Collections.Generic;
using Project208.Services.DTOs;
using AutoMapper;
using System.Threading.Tasks;
using Project208.Services.DTOs.CustomerDTOs;

namespace Project208.Services.Concrete
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository customerRepository;
        private ILocationService locationService;
        private IMapper mapper;

        public CustomerService(ICustomerRepository customerRepoParam, ILocationService locationServiceParam,
            IMapper mapperParam)
        {
            customerRepository = customerRepoParam;
            locationService = locationServiceParam;
            mapper = mapperParam;
        }

        public async Task<CustomerDTO> UpdateCustomerAsync(CustomerDTO cusDTOParam)
        {
            CustomerDTO customerDTO = null;
            var customer = await customerRepository.UpdateCustomerAsync(mapper.Map<CustomerDTO, Customer>(cusDTOParam));

            if (customer != null)
            {
                customerDTO = mapper.Map<Customer, CustomerDTO>(customer);
            }

            return customerDTO;
        }

        public async Task<CustomerDTO> DeleteCustomerAsync(int customerId)
        {
            CustomerDTO customerDTO = null;
            var customer = await customerRepository.DeleteCustomerAsync(customerId);
            
            if (customer != null)
            {
                customerDTO = mapper.Map<Customer, CustomerDTO>(customer);
            }

            return customerDTO;
        }

        public async Task<CustomerDTO> CreateCustomerAsync(CustomerDTO cusDTOParam)
        {
            cusDTOParam.CustomerId = 0;

            var customer = await customerRepository.CreateCustomerAsync(mapper.Map<CustomerDTO, Customer>(cusDTOParam));
            CustomerDTO customerDTO = mapper.Map<Customer, CustomerDTO>(customer);

            return customerDTO;
        }

        public async Task<IEnumerable<CustomerDTO>> GetCustomersByFilterDataAsync(int locationId, string searchString)
        {
            IEnumerable<CustomerDTO> customersDTO = null;

            if (await locationService.GetLocationByIdAsync(locationId) != null)
            {
                var customers = await customerRepository.GetCustomersByFilterDataAsync(locationId, searchString);
                customersDTO = mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDTO>>(customers);
            }

            return customersDTO;
        }

        public async Task<IEnumerable<CustomersInfoDTO>> GetCustomersInfoAsync()
        {
            List<CustomersInfoDTO> customersInfo = new List<CustomersInfoDTO>();

            for (int i = 1; i <= await locationService.LocationsCountAsync(); i++)
            {
                var location = await locationService.GetLocationByIdAsync(i);

                LocationDTO locationDTO = new LocationDTO
                {
                    LocationId   = location.LocationId,
                    LocationName = location.Name
                };

                CustomersInfoDTO customerInfo = new CustomersInfoDTO
                {
                    Location       = locationDTO,
                    CustomersCount = await customerRepository.GetCustomersCountByLocationIdAsync(i)
                };

                customersInfo.Add(customerInfo);
            }

            return customersInfo;
        }

        public async Task<CustomerDTO> GetCustomerByIdAsync(int customerId)
        {
            CustomerDTO customerDTO = null;
            var customer = await customerRepository.GetCustomerByIdAsync(customerId);

            if (customer != null)
            {
                customerDTO = mapper.Map<Customer, CustomerDTO>(customer);
            }

            return customerDTO;
        }
    }
}
