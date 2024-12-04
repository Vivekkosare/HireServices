
using HireServices.Features.ServiceProviders.Domain.AggregateRoots;
using MediatR;

namespace HireServices.Features.ServiceProviders.Queries
{
    public record GetServiceProviderQuery(Guid customerId) : IRequest<ServiceProviderOutput>
    {
    }
}
