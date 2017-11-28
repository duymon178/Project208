using System;

namespace Project208.Services.DTOs.SearchResultDTOs
{
    public class T1SearchResultDTO : SearchResultDTO
    {
        public int AmountPerDay { get; set; }
        public int TotalUnpaidDays { get; set; }
        public int TotalPaidDays { get; set; }
        public int Interest { get; set; }
        public int? SlowlyReturnAmountPerDay { get; set; }
        public int? RenewTo { get; set; }
        public int? RenewFrom { get; set; }
        public string FormattedTotalUnpaidDays { get; set; }              /* = (TotalLeft/AmountPerDay) */
        public string FormattedTotalPaidDays { get; set; }                /* = (TotalDays - TotalUnpaidDays) */
        public string ContractInformation { get; set; }                  /* "Amount/TotalDays/AmountPerDay" */
        public DateTime? LastReturnDate { get; set; }
        public DateTime? RenewDate { get; set; }
    }
}
