using HireServices.Features.ServiceProviders.GraphQL.Inputs;
using MediatR;

namespace HireServices.Features.ServiceProviders.Commands
{
    public record CreateServiceProviderCommand(ServiceProviderInput Input) : IRequest<Domain.AggregateRoots.ServiceProviderOutput>
    {
    }
}
