using FluentValidation;
using HireServices.Features.Customers.Mutations.Handlers;

namespace HireServices.Features.Customers.Mutations.Validators;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(x => x.Input).NotNull().WithMessage("Customer input is required.");

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
        });
    }
}
