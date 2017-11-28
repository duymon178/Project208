using Project208.Domain.Enums;

namespace Project208.Services.DTOs.ContractDTOs
{
    public class T2ContractDTO : IContractTypeDTO
    {
        public string ContractTypeName { get; set; } = "Khoản";
        public int ContractTypeId { get; set; } = (int)ContractTypeEnum.Type2;
    }
}
