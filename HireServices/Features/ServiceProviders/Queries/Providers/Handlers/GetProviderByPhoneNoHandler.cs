using HireServices.Features.ServiceProviders.DTOs;
using HireServices.Features.ServiceProviders.Extensions;
using HireServices.Features.ServiceProviders.Services;
using MediatR;

namespace HireServices.Features.ServiceProviders.Queries.Providers.Handlers;

public record GetProviderByPhoneNoQuery(string PhoneNo) : IRequest<ProviderOutput?>;

public class GetProviderByPhoneNoHandler : IRequestHandler<GetProviderByPhoneNoQuery, ProviderOutput?>
{
    private readonly IProviderServicesService _providerService;

    public GetProviderByPhoneNoHandler(IProviderServicesService providerService)
    {
        _providerService = providerService;
    }

    public async Task<ProviderOutput?> Handle(GetProviderByPhoneNoQuery request, CancellationToken cancellationToken)
    {
        var provider = await _providerService.GetProviderByPhoneNumberAsync(request.PhoneNo);
        return provider?.ToProviderOutput();
    }
}
