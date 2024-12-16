using HireServices.Features.ServiceProviders.Domain.AggregateRoots;
using HireServices.Features.ServiceProviders.DTOs;
using MediatR;

namespace HireServices.Features.ServiceProviders.Queries.GetServicesProvider
{
    public record GetProviderQuery(Guid customerId) : IRequest<ProviderOutput>
    {
    }
}
