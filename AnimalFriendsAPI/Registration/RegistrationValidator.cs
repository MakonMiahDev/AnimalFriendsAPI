using AnimalFriends.Models;
using FluentValidation;

namespace AnimalFriends.Registration
{
    public class RegistrationValidator : AbstractValidator<CustomerRegistration>
    {
        public RegistrationValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required")
                .Length(3, 50);

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required")
                .Length(3, 50);

            RuleFor(x => x.PolicyReference)
                .NotEmpty()
                .Matches("^[A-Z]{2}-\\d{6}$").WithMessage("Policy reference must be in format XX-999999");

            RuleFor(x => x)
                .Must(x => x.DateOfBirth != null || !string.IsNullOrEmpty(x.Email))
                .WithMessage("Either Date of Birth or Email must be provided");

            When(x => x.DateOfBirth.HasValue, () =>
            {
                RuleFor(x => x.DateOfBirth.Value)
                    .Must(dob => dob <= DateTime.Today.AddYears(-18))
                    .WithMessage("Customer must be at least 18 years old");
            });

            When(x => !string.IsNullOrEmpty(x.Email), () =>
            {
                RuleFor(x => x.Email)
                    .Matches("^[a-zA-Z0-9]{4,}@[a-zA-Z0-9]{2,}\\.(com|co.uk)$")
                    .WithMessage("Invalid email format");
            });
        }
    }
}
