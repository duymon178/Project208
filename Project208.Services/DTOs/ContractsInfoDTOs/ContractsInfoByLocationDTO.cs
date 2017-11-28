using System.Collections.Generic;

namespace Project208.Services.DTOs.ContractsInfoDTOs
{
    public class ContractsInfoByLocationDTO
    {
        public LocationDTO Location { get; set; }
        public IEnumerable<ContractsInfoByTypeDTO> ContractsInfo { get; set; }
    }
}
