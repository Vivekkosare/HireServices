using HireServices.Features.ServiceProviders.Domain.AggregateRoots;
using MediatR;

namespace HireServices.Features.ServiceProviders.Queries
{
    public record GetServiceProvidersQuery(int PageSize): IRequest<List<ServiceProviderOutput>>
    {
    }
}
