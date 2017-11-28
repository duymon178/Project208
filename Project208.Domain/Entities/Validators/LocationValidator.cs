using FluentValidation;

namespace Project208.Domain.Entities.Validators
{
    public class LocationValidator : AbstractValidator<Location>
    {
        public LocationValidator()
        {
            RuleFor(location => location.LocationId).NotNull();
            RuleFor(location => location.Name).NotEmpty().WithMessage("Tên khu vực không được để trống.");
        }
    }
}
