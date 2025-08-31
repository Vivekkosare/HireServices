using System;
using HireServices.Features.ServiceProviders.Services;
using MediatR;

namespace HireServices.Features.ServiceProviders.Query.Providers.Handlers;

public record ProviderExistsRequest(string PhoneNo) : IRequest<bool>;
public class ProviderExistsHandler : IRequestHandler<ProviderExistsRequest, bool>
{
    private readonly IProviderServicesService _providerServicesService;

    public ProviderExistsHandler(IProviderServicesService providerServicesService)
    {
        _providerServicesService = providerServicesService;
    }

    public async Task<bool> Handle(ProviderExistsRequest request, CancellationToken cancellationToken)
    {
        return await _providerServicesService.ProviderExistsByPhoneNoAsync(request.PhoneNo);
    }
}
