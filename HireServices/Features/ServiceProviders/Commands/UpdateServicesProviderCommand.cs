using HireServices.Features.ServiceProviders.GraphQL.Inputs;
using MediatR;

namespace HireServices.Features.ServiceProviders.Commands
{
    public record UpdateServicesProviderCommand(Guid serviceProviderId, ServicesProviderInput input) : IRequest<Domain.AggregateRoots.ServiceProviderOutput>;
}
