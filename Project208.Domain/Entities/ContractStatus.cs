using System.Collections.Generic;

namespace Project208.Domain.Entities
{
    public class ContractStatus
    {
        public int ContractStatusID { get; set; }
        public string Status { get; set; }
        public string Vnese { get; set; }

        // Navigation properties:
        public ICollection<T1Contract> T1Contracts { get; set; }
        public ICollection<T2Contract> T2Contracts { get; set; }
    }
}
