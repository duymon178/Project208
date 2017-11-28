using Project208.Services.DTOs.SearchResultDTOs;
using System.Collections.Generic;

namespace Project208.Services.DTOs.CustomerDTOs
{
    public class CustomerContractsDTO
    {
        public IEnumerable<SearchResultDTO> T1Contracts { get; set; }
        public IEnumerable<SearchResultDTO> T2Contracts { get; set; }
    }
}
