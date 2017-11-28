using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project208.Domain.Entities
{
    public class T2Contract
    {
        [Key]
        public int ContractId { get; set; }

        public DateTime BorrowDate { get; set; }
        public DateTime? CheckoutDate { get; set; }
        public DateTime? UnableToPayStartDate { get; set; }
        public DateTime? SlowlyReturnStartDate { get; set; }
        public DateTime? SlowlyReturnDate { get; set; }

        public int Amount { get; set; }
        public int ActualLendMoney { get; set; }
        public int TotalLeft { get; set; }
        public int InterestRate { get; set; }
        public int Period { get; set; }
        public int AmountPerPeriod { get; set; }
        public int? ReturnAfterCheckout { get; set; }

        public string Items { get; set; }
        public string ContractNote { get; set; }

        // Foreign keys:
        public int CustomerId { get; set; }
        public int ContractStatusId { get; set; }
        public int SlowlyReturnTypeId { get; set; }

        // Navigation properties:
        public Customer Customer { get; set; }
        public ContractStatus ContractStatus { get; set; }
        public SlowlyReturnType SlowlyReturnType { get; set; }
        public ICollection<T2PaymentDetail> T2PaymentDetails { get; set; }
    }
}
