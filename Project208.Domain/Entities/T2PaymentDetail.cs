using System;
using System.ComponentModel.DataAnnotations;

namespace Project208.Domain.Entities
{
    public class T2PaymentDetail
    {
        [Key]
        public int PaymentDetailID { get; set; }

        public int Amount { get; set; }
        public int ExtraMoney { get; set; }

        public DateTime? NeedToPayDate { get; set; }
        public DateTime? ActualPayDate { get; set; }

        // Foreign key:        
        public int ContractID { get; set; }

        // Navigation property:
        public T2Contract ContractType2 { get; set; }
    }
}
