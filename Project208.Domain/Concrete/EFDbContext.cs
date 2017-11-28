using Microsoft.EntityFrameworkCore;
using Project208.Domain.Entities;

namespace Project208.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        /*
         We now use the name of the DbSet property for the table name in the database.
         If no DbSet property is defined for the given entity type, then the entity class name is used.
        */
        public DbSet<Note> Notes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<T1Contract> T1Contracts { get; set; }
        public DbSet<T2Contract> T2Contracts { get; set; }
        public DbSet<ContractStatus> ContractStatuses { get; set; }
        public DbSet<SlowlyReturnType> SlowlyReturnTypes { get; set; }
        public DbSet<T1PaymentDetail> T1PaymentDetails{ get; set; }
        public DbSet<T2PaymentDetail> T2PaymentDetails { get; set; }

        public EFDbContext(DbContextOptions<EFDbContext> options)
            : base(options) { }
    }
}
