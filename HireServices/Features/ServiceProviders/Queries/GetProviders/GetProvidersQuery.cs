using HireServices.Features.ServiceProviders.DTOs;
using MediatR;

namespace HireServices.Features.ServiceProviders.Queries.GetProviders
{
    public record GetProvidersQuery(int PageSize) : IRequest<List<ProviderOutput>>
    {
    }
}
