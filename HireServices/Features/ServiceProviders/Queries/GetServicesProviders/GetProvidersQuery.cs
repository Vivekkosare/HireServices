using HireServices.Features.ServiceProviders.Domain.AggregateRoots;
using HireServices.Features.ServiceProviders.DTOs;
using MediatR;

namespace HireServices.Features.ServiceProviders.Queries.GetServicesProviders
{
    public record GetProvidersQuery(int PageSize) : IRequest<List<ProviderOutput>>
    {
    }
}
