using HireServices.Features.ServiceProviders.GraphQL.Inputs;
using MediatR;

namespace HireServices.Features.ServiceProviders.Commands
{
    public record UpdateServiceProviderCommand(Guid serviceProviderId, ServiceProviderInput input) : IRequest<Domain.AggregateRoots.ServiceProviderOutput>;
}
