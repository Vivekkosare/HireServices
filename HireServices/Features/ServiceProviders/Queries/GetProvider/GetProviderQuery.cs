using HireServices.Features.ServiceProviders.Domain.AggregateRoots;
using HireServices.Features.ServiceProviders.DTOs;
using MediatR;

namespace HireServices.Features.ServiceProviders.Queries.GetProvider
{
    public record GetProviderQuery(Guid CustomerId) : IRequest<ProviderOutput>
    {
    }
}
