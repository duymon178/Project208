using System;
using System.ComponentModel.DataAnnotations;

namespace Project208.Domain.Entities
{
    public class T1PaymentDetail
    {
        [Key]
        public int PaymentDetailId { get; set; }

        public int Amount { get; set; }
        public int ExtraMoney { get; set; }

        public DateTime? NeedToPayDate { get; set; }
        public DateTime? ActualPayDate { get; set; }

        // Foreign key:
        public int ContractId { get; set; }

        // Navigation property:
        public T1Contract T1Contract { get; set; }
    }
}
