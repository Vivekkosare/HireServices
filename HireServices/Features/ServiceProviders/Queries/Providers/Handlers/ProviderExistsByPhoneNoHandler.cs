using HireServices.Features.ServiceProviders.Services;
using MediatR;

namespace HireServices.Features.ServiceProviders.Queries.Providers.Handlers;

public record ProviderExistsByPhoneNoQuery(string PhoneNo) : IRequest<bool>;

public class ProviderExistsByPhoneNoHandler : IRequestHandler<ProviderExistsByPhoneNoQuery, bool>
{
    private readonly IProviderServicesService _providerServicesService;

    public ProviderExistsByPhoneNoHandler(IProviderServicesService providerServicesService)
    {
        _providerServicesService = providerServicesService;
    }

    public async Task<bool> Handle(ProviderExistsByPhoneNoQuery request, CancellationToken cancellationToken)
    {
        return await _providerServicesService.ProviderExistsByPhoneNoAsync(request.PhoneNo);
    }
}
