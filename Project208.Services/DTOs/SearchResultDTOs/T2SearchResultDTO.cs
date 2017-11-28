namespace Project208.Services.DTOs.SearchResultDTOs
{
    public class T2SearchResultDTO : SearchResultDTO
    {
        public int InterestRate { get; set; }
        public new int UnpaidDays { get; set; }
        public int AmountPerPeriod { get; set; }
        public string PeriodInformation { get; set; }
    }
}
