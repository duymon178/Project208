using FluentValidation;

namespace Project208.WebUI.Models.Validators
{
    public class CreateCustomerViewModelValidator : AbstractValidator<CreateCustomerViewModel>
    {
        public CreateCustomerViewModelValidator()
        {
            RuleFor(customer => customer.LocationId)
                .NotEmpty().WithMessage("Khu vực không được để trống");

            RuleFor(customer => customer.CustomerName)
                .NotEmpty().WithMessage("Tên khách hàng không được để trống.")
                .MinimumLength(2).WithMessage("Tên khách hàng phải dài hơn 1 ký tự.")
                .MaximumLength(50).WithMessage("Tên khách hàng quá dài.");

            RuleFor(customer => customer.CustomerAddress)
                .NotEmpty().WithMessage("Địa chỉ không được để trống.")
                .MaximumLength(100).WithMessage("Địa chỉ quá dài.");

            RuleFor(customer => customer.CustomerPhoneNumber)
                .Matches("(\\+84|0)\\d{9,10}").WithMessage("Số điện thoại không hợp lệ.");
        }
    }
}
