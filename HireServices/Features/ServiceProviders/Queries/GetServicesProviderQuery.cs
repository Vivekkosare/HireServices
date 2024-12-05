
using HireServices.Features.ServiceProviders.Domain.AggregateRoots;
using MediatR;

namespace HireServices.Features.ServiceProviders.Queries
{
    public record GetServicesProviderQuery(Guid customerId) : IRequest<ServiceProviderOutput>
    {
    }
}
