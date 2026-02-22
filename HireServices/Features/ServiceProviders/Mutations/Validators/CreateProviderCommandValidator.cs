using FluentValidation;
using HireServices.Features.ServiceProviders.Mutations.Handlers;

namespace HireServices.Features.ServiceProviders.Mutations.Validators;

public class CreateProviderCommandValidator : AbstractValidator<CreateProviderCommand>
{
    public CreateProviderCommandValidator()
    {
        RuleFor(x => x.Input).NotNull().WithMessage("Provider input is required.");

        When(x => x.Input != null, () =>
        {
            RuleFor(x => x.Input.ContactInfoInput).NotNull().WithMessage("Contact info is required.");

            When(x => x.Input.ContactInfoInput != null, () =>
            {
                RuleFor(x => x.Input.ContactInfoInput.FirstName).NotEmpty().WithMessage("First name is required.");
                RuleFor(x => x.Input.ContactInfoInput.LastName).NotEmpty().WithMessage("Last name is required.");
                RuleFor(x => x.Input.ContactInfoInput.Email).NotEmpty().EmailAddress().WithMessage("A valid email is required.");
                RuleFor(x => x.Input.ContactInfoInput.PhoneNumber).NotEmpty().WithMessage("Phone number is required.");
                RuleFor(x => x.Input.ContactInfoInput.DateOfBirth).LessThan(DateTime.UtcNow).WithMessage("Date of birth must be in the past.");
            });

            RuleFor(x => x.Input.AddressInput).NotNull().WithMessage("Address is required.");

            When(x => x.Input.AddressInput != null, () =>
            {
                RuleFor(x => x.Input.AddressInput.Street).NotEmpty().WithMessage("Street is required.");
                RuleFor(x => x.Input.AddressInput.City).NotEmpty().WithMessage("City is required.");
                RuleFor(x => x.Input.AddressInput.State).NotEmpty().WithMessage("State is required.");
                RuleFor(x => x.Input.AddressInput.ZipCode).NotEmpty().WithMessage("Zip code is required.");
                RuleFor(x => x.Input.AddressInput.Country).NotEmpty().WithMessage("Country is required.");
            });

            RuleFor(x => x.Input.ServicesInput).NotEmpty().WithMessage("At least one service is required.");

            RuleForEach(x => x.Input.ServicesInput).ChildRules(service =>
            {
                service.RuleFor(s => s.Name).NotEmpty().WithMessage("Service name is required.");
                service.RuleFor(s => s.Price).GreaterThan(0).WithMessage("Price must be greater than 0.");
                service.RuleFor(s => s.Currency).NotEmpty().Length(3).WithMessage("Currency must be a 3-character code.");
                service.RuleFor(s => s.Duration).NotEmpty().WithMessage("Duration is required.");
                service.RuleFor(s => s.CategoryInput).NotNull().WithMessage("Category is required.");
            });
        });
    }
}
