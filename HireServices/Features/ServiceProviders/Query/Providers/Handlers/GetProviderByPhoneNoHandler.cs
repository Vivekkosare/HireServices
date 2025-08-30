using System;
using HireServices.Features.ServiceProviders.DTOs;
using HireServices.Features.ServiceProviders.Extensions;
using HireServices.Features.ServiceProviders.Services;
using MediatR;

namespace HireServices.Features.ServiceProviders.Query.Providers.Handlers;

public record GetProviderByPhoneNoRequest(string PhoneNo) : IRequest<ProviderOutput?>;
public class GetProviderByPhoneNoHandler(IProviderServicesService _providerService) : IRequestHandler<GetProviderByPhoneNoRequest, ProviderOutput?>
{
    public async Task<ProviderOutput?> Handle(GetProviderByPhoneNoRequest request, CancellationToken cancellationToken)
    {
        var provider = await _providerService.GetProviderByPhoneNumberAsync(request.PhoneNo);
        return provider?.ToProviderOutput();
    }
}
