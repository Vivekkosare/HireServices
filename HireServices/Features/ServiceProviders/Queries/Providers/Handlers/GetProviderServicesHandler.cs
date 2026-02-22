using HireServices.Common.Exceptions;
using HireServices.Features.ServiceProviders.DTOs;
using HireServices.Features.ServiceProviders.Extensions;
using HireServices.Features.ServiceProviders.Services;
using MediatR;

namespace HireServices.Features.ServiceProviders.Queries.Providers.Handlers;

public record GetProviderServicesQuery(Guid ProviderId) : IRequest<List<ProviderServiceOutput>>;

public class GetProviderServicesHandler : IRequestHandler<GetProviderServicesQuery, List<ProviderServiceOutput>>
{
    private readonly IProviderServicesService _providerService;

    public GetProviderServicesHandler(IProviderServicesService providerService)
    {
        _providerService = providerService;
    }

    public async Task<List<ProviderServiceOutput>> Handle(GetProviderServicesQuery request, CancellationToken cancellationToken)
    {
        var providerServices = await _providerService.GetProviderServicesByProviderIdAsync(request.ProviderId);
        if (providerServices == null || !providerServices.Any())
        {
            throw new NotFoundException("No services found for the provider");
        }
        return providerServices.ToProviderServiceOutputList();
    }
}
