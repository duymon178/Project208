using FluentValidation;

namespace Project208.WebUI.Models.Validators
{
    public class T1ContractDetailViewModelValidator : AbstractValidator<T1ContractDetailViewModel>
    {
        public T1ContractDetailViewModelValidator()
        {
            RuleFor(contract => contract.ContractId).NotEmpty();
            RuleFor(contract => contract.ContractStatusId).NotEmpty();
        }
    }
}
