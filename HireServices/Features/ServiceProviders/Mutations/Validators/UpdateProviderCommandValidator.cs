using FluentValidation;
using HireServices.Features.ServiceProviders.Mutations.Handlers;

namespace HireServices.Features.ServiceProviders.Mutations.Validators;

public class UpdateProviderCommandValidator : AbstractValidator<UpdateProviderCommand>
{
    public UpdateProviderCommandValidator()
    {
        RuleFor(x => x.ProviderId).NotEmpty().WithMessage("Provider ID is required.");
        RuleFor(x => x.UpdateInput).NotNull().WithMessage("Update input is required.");

        When(x => x.UpdateInput != null, () =>
        {
            RuleFor(x => x.UpdateInput.ContactInfoInput).NotNull().WithMessage("Contact info is required.");

            When(x => x.UpdateInput.ContactInfoInput != null, () =>
            {
                RuleFor(x => x.UpdateInput.ContactInfoInput.FirstName).NotEmpty().WithMessage("First name is required.");
                RuleFor(x => x.UpdateInput.ContactInfoInput.LastName).NotEmpty().WithMessage("Last name is required.");
                RuleFor(x => x.UpdateInput.ContactInfoInput.Email).NotEmpty().EmailAddress().WithMessage("A valid email is required.");
                RuleFor(x => x.UpdateInput.ContactInfoInput.PhoneNumber).NotEmpty().WithMessage("Phone number is required.");
                RuleFor(x => x.UpdateInput.ContactInfoInput.DateOfBirth).LessThan(DateTime.UtcNow).WithMessage("Date of birth must be in the past.");
            });

            RuleFor(x => x.UpdateInput.AddressInput).NotNull().WithMessage("Address is required.");

            When(x => x.UpdateInput.AddressInput != null, () =>
            {
                RuleFor(x => x.UpdateInput.AddressInput.Street).NotEmpty().WithMessage("Street is required.");
                RuleFor(x => x.UpdateInput.AddressInput.City).NotEmpty().WithMessage("City is required.");
                RuleFor(x => x.UpdateInput.AddressInput.State).NotEmpty().WithMessage("State is required.");
                RuleFor(x => x.UpdateInput.AddressInput.ZipCode).NotEmpty().WithMessage("Zip code is required.");
                RuleFor(x => x.UpdateInput.AddressInput.Country).NotEmpty().WithMessage("Country is required.");
            });
        });
    }
}
