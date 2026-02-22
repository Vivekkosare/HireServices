using FluentValidation;
using HireServices.Features.ServiceProviders.Mutations.Handlers;

namespace HireServices.Features.ServiceProviders.Mutations.Validators;

public class DeleteProviderCommandValidator : AbstractValidator<DeleteProviderCommand>
{
    public DeleteProviderCommandValidator()
    {
        RuleFor(x => x.ProviderId).NotEmpty().WithMessage("Provider ID is required.");
    }
}
