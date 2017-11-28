using FluentValidation;

namespace Project208.Domain.Entities.Validators
{
    public class T1ContractValidator : AbstractValidator<T1Contract>
    {
        public T1ContractValidator()
        {
            RuleFor(ct1 => ct1.ContractId).NotNull();
            RuleFor(ct1 => ct1.BorrowDate).NotNull().WithMessage("Ngày lấy không được để trống.");

            RuleFor(ct1 => ct1.Amount)
                .NotEmpty().WithMessage("Số tiền vay không được để trống.")
                .GreaterThanOrEqualTo(1000).WithMessage("Bát họ phải từ 1 triệu (1000) trở lên.");

            RuleFor(ct1 => ct1.TotalDays)
                .NotNull().WithMessage("Số ngày không được để trống.")
                .InclusiveBetween(10, 365).WithMessage("Số ngày phải từ 10 ngày trở lên.");

            RuleFor(ct1 => ct1.ActualLendMoney)
                .NotNull().WithMessage("Số tiền xuất thực không được để trống.")
                .GreaterThanOrEqualTo(1000).WithMessage("Tiền xuất thực phải từ 1 triệu (1000) trở lên.")
                .LessThan(ct1 => ct1.Amount).WithMessage("Số tiền xuất thực phải ít hơn số tiền cho vay.");

            RuleFor(ct1 => ct1.CustomerId)
                .NotEmpty().WithMessage("Mã khách hàng không được để trống.");
        }
    }
}