using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project208.Domain.Entities
{
    public class T1Contract
    {
        [Key]
        public int ContractId { get; set; }

        public DateTime BorrowDate { get; set; }
        public DateTime? CheckoutDate { get; set; }
        public DateTime? UnableToPayStartDate { get; set; }
        public DateTime? SlowlyReturnStartDate { get; set; }
        public DateTime? RenewDate { get; set; }
        public DateTime? LastReturnDate { get; set; }

        public int Amount { get; set; }
        public int TotalDays { get; set; }
        public int ActualLendMoney { get; set; }

        public int AmountPerDay { get; set; }
        public int Interest { get; set; }
        public int TotalLeft { get; set; }
        public int ContractStatusId { get; set; }

        public string Items { get; set; }
        public string ContractNote { get; set; }

        // Foreign keys:
        public int CustomerId { get; set; }
        public int? SlowlyReturnAmountPerDay { get; set; }
        public int? RenewTo { get; set; }
        public int? RenewFrom { get; set; }

        // Navigation properties:
        public Customer Customer { get; set; }
        public ContractStatus ContractStatus { get; set; }
        public ICollection<T1PaymentDetail> T1PaymentDetails { get; set; }
    }
}
