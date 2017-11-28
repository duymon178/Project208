using Project208.Services.DTOs.ContractDTOs;

namespace Project208.Services.DTOs.ContractsInfoDTOs
{
    public class ContractsInfoByTypeDTO
    {
        public IContractTypeDTO ContractType { get; set; }
        public int PayingContracts { get; set; }
        public int SlowlyContracts { get; set; }
        public int UnableContracts { get; set; }
    }
}
