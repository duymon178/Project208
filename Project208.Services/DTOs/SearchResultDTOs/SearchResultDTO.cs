using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Project208.Services.DTOs.SearchResultDTOs
{
    [KnownType(typeof(T1SearchResultDTO))]
    [KnownType(typeof(T2SearchResultDTO))]
    public class SearchResultDTO
    {
        public int ContractId { get; set; }
        public int CustomerId { get; set; }
        public int ContractStatusId { get; set; }
        public int LocationId { get; set; }
        public int TotalLeft { get; set; }
        public int Amount { get; set; }
        public int PaidAmount { get; set; }
        public int TotalDays { get; set; }
        public int ActualLendMoney { get; set; }
        public string ContractStatus { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerNote { get; set; }
        public string ContractNote { get; set; }
        public string Items { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? UnableToPayStartDate { get; set; }
        public DateTime? SlowlyReturnStartDate { get; set; }
        public IEnumerable<DateTime?> UnpaidDays { get; set; }
    }
}
