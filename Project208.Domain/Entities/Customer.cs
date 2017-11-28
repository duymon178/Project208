using System.Collections.Generic;

namespace Project208.Domain.Entities
{
    public class Customer
    {
        public int  CustomerId { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Note { get; set; }

        // Foreign key:
        public int LocationId { get; set; }

        // Navigation properties:
        public Location Location { get; set; }
        public ICollection<T1Contract> T1Contracts { get; set; }
        public ICollection<T2Contract> T2Contracts { get; set; }
    }
}
