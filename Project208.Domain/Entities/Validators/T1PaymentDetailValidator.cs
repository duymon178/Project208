using FluentValidation;

namespace Project208.Domain.Entities.Validators
{
    public class T1PaymentDetailValidator : AbstractValidator<T1PaymentDetail>
    {
        public T1PaymentDetailValidator()
        {
            RuleFor(pm => pm.PaymentDetailId).NotEmpty().WithMessage("\u2022 Chưa chọn buổi để thao tác.");
            RuleFor(pm => pm.Amount).NotNull().WithMessage("Số tiền đóng không được để trống.");
        }
    }
}
