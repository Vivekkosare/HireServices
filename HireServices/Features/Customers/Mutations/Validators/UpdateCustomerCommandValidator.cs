using FluentValidation;
using HireServices.Features.Customers.Mutations.Handlers;

namespace HireServices.Features.Customers.Mutations.Validators;

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(x => x.CustomerId).NotEmpty().WithMessage("Customer ID is required.");
        RuleFor(x => x.CustomerInput).NotNull().WithMessage("Customer input is required.");

        When(x => x.CustomerInput != null, () =>
        {
            RuleFor(x => x.CustomerInput.ContactInfoInput).NotNull().WithMessage("Contact info is required.");

            When(x => x.CustomerInput.ContactInfoInput != null, () =>
            {
                RuleFor(x => x.CustomerInput.ContactInfoInput.FirstName).NotEmpty().WithMessage("First name is required.");
                RuleFor(x => x.CustomerInput.ContactInfoInput.LastName).NotEmpty().WithMessage("Last name is required.");
                RuleFor(x => x.CustomerInput.ContactInfoInput.Email).NotEmpty().EmailAddress().WithMessage("A valid email is required.");
                RuleFor(x => x.CustomerInput.ContactInfoInput.PhoneNumber).NotEmpty().WithMessage("Phone number is required.");
                RuleFor(x => x.CustomerInput.ContactInfoInput.DateOfBirth).LessThan(DateTime.UtcNow).WithMessage("Date of birth must be in the past.");
            });
        });
    }
}
