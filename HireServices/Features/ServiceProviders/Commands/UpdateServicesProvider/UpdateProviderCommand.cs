using HireServices.Features.ServiceProviders.DTOs;
using HireServices.Features.ServiceProviders.GraphQL.Inputs;
using MediatR;

namespace HireServices.Features.ServiceProviders.Commands.UpdateServicesProvider
{
    public record UpdateProviderCommand(Guid ProviderId, ProviderUpdateInput UpdateInput) : IRequest<ProviderOutput>;
}
