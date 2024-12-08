using HireServices.Features.ServiceProviders.Domain.AggregateRoots;
using HireServices.Features.ServiceProviders.DTOs;
using HireServices.Features.ServiceProviders.GraphQL.Inputs;
using MediatR;

namespace HireServices.Features.ServiceProviders.Commands.UpdateServicesProvider
{
    public record UpdateServicesProviderCommand(Guid serviceProviderId, ServicesProviderInput input) : IRequest<ServicesProviderOutput>;
}
