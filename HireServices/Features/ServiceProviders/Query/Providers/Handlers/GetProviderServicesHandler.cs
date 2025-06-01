using HireServices.Features.ServiceProviders.DTOs;
using HireServices.Features.ServiceProviders.Extensions;
using HireServices.Features.ServiceProviders.Services;
using MediatR;

namespace HireServices.Features.ServiceProviders.Query.ProviderServices.Handlers;

public record GetProviderServicesQuery(Guid ProviderId) : IRequest<List<ProviderServiceOutput>>
{

}
public class GetProviderServicesHandler(IProviderServicesService _providerService) : IRequestHandler<GetProviderServicesQuery, List<ProviderServiceOutput>>
{
    public async Task<List<ProviderServiceOutput>> Handle(GetProviderServicesQuery request, CancellationToken cancellationToken)
    {
        var providerServices = await _providerService.GetProviderServicesByProviderIdAsync(request.ProviderId);
        if (providerServices == null || !providerServices.Any())
        {
            throw new Exception("No services found for the provider");
        }
        return providerServices.ToProviderServiceOutputList();
    }
}
