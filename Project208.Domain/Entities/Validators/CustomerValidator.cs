using FluentValidation;

namespace Project208.Domain.Entities.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.CustomerId).NotNull();
            RuleFor(customer => customer.LocationId).NotEmpty();

            RuleFor(customer => customer.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);

            RuleFor(customer => customer.Address)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(customer => customer.PhoneNumber)
                .Matches("(\\+84|0)\\d{9,10}");
        }
    }
}
