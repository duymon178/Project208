namespace Project208.Services.DTOs.CustomerDTOs
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        public int LocationId { get; set; }

        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerNote { get; set; }
    }
}
