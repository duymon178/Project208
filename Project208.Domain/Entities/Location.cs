using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project208.Domain.Entities
{
    public class Location
    {
        public int LocationId { get; set; }
        public string Name { get; set; }

        // Navigation property:
        public ICollection<Customer> Customers { get; set; }
    }
}
