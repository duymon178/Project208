using Project208.Domain.Entities.Validators;
using Xunit;
using FluentValidation.TestHelper;

namespace Project208.Tests.Validators
{
    public class CustomerValidatorTests
    {
        private CustomerValidator validator;

        public CustomerValidatorTests()
        {
            validator = new CustomerValidator();
        }

        [Fact]
        public void Should_have_error_when_Name_is_null()
        {
            validator.ShouldHaveValidationErrorFor(customer => customer.Name, null as string);
        }

        [Fact]
        public void Should_have_error_when_PhoneNumber_does_not_match()
        {
            validator.ShouldHaveValidationErrorFor(customer => customer.PhoneNumber, "09456");
        }
    }
}
