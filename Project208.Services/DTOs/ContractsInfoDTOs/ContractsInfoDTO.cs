using System.Collections.Generic;

namespace Project208.Services.DTOs.ContractsInfoDTOs
{
    public class ContractsInfoDTO
    {
        /* Daily */
        public IEnumerable<ContractsInfoByLocationDTO> DailyInfo { get; set; }

        /* Total */
        public IEnumerable<ContractsInfoByLocationDTO> TotalInfo { get; set; }
    }
}
