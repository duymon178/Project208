using Project208.Domain.Abstract;
using System.Collections.Generic;
using Project208.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Project208.Domain.Concrete
{
    public class EFCustomerRepository : ICustomerRepository
    {
        private EFDbContext context;

        public EFCustomerRepository(EFDbContext ctx)
        {
            context = ctx;
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            Customer dbCustomer = await context.Customers.FirstOrDefaultAsync(c => c.CustomerId == customer.CustomerId);

            if (dbCustomer != null)
            {
                dbCustomer.Name        = customer.Name;
                dbCustomer.Address     = customer.Address;
                dbCustomer.PhoneNumber = customer.PhoneNumber;
                dbCustomer.Note        = customer.Note;
                dbCustomer.LocationId  = customer.LocationId;

                await context.SaveChangesAsync();
            }

            return dbCustomer;
        }

        public async Task<Customer> DeleteCustomerAsync(int CustomerId)
        {
            Customer customer = await context.Customers.FirstOrDefaultAsync(c => c.CustomerId == CustomerId);

            if (customer != null)
            {
                context.Customers.Remove(customer);
                await context.SaveChangesAsync();
            }

            return customer;
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            context.Customers.Add(customer);
            await context.SaveChangesAsync();

            return customer;
        }

        public async Task<IEnumerable<Customer>> GetCustomersByFilterDataAsync(int LocationId, string searchString)
        {
            var customers = context.Customers.Where(c => c.LocationId == LocationId);

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                customers = customers.Where(c => c.Name.StartsWith(searchString));
            }

            return await customers.OrderBy(c => c.Name).AsNoTracking().ToListAsync();
        }

        public async Task<int> GetCustomersCountByLocationIdAsync(int LocationId)
            => await context.Customers.Where(c => c.LocationId == LocationId).CountAsync();

        public async Task<Customer> GetCustomerByIdAsync(int CustomerId)
            => await context.Customers.AsNoTracking().FirstOrDefaultAsync(c => c.CustomerId == CustomerId);
    }
}
