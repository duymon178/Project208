using System.Collections.Generic;

namespace Project208.Domain.Entities
{
    public class SlowlyReturnType
    {
        public int SlowlyReturnTypeId { get; set; }
        public string TypeDescription { get; set; }

        // Navigation property:
        public ICollection<T2Contract> T2Contracts { get; set; }
    }
}
