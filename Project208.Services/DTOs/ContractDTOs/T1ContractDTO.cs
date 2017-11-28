using Project208.Domain.Enums;

namespace Project208.Services.DTOs.ContractDTOs
{
    public class T1ContractDTO : IContractTypeDTO
    {
        public string ContractTypeName { get; set; } = "Họ";
        public int ContractTypeId { get; set; } = (int)ContractTypeEnum.Type1;
    }
}
