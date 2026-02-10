using HireServices.Features.ServiceProviders.DTOs;
using HireServices.Features.ServiceProviders.Extensions;
using HireServices.Features.ServiceProviders.Services;
using MediatR;

namespace HireServices.Features.ServiceProviders.Query.Providers.Handlers;

// ============================================================================
// Query Requests
// ============================================================================

public record GetProvidersQuery(int PageSize) : IRequest<List<ProviderOutput>>;

public record GetProviderQuery(Guid CustomerId) : IRequest<ProviderOutput>;

public record GetProviderByPhoneNoRequest(string PhoneNo) : IRequest<ProviderOutput?>;

public record ProviderExistsRequest(string PhoneNo) : IRequest<bool>;

public record GetProviderServicesQuery(Guid ProviderId) : IRequest<List<ProviderServiceOutput>>;

// ============================================================================
// Query Handlers
// ============================================================================

public class GetProvidersHandler : IRequestHandler<GetProvidersQuery, List<ProviderOutput>>
{
    private readonly IProviderServicesService _providerService;

    public GetProvidersHandler(IProviderServicesService providerService)
    {
        _providerService = providerService;
    }

    public async Task<List<ProviderOutput>> Handle(GetProvidersQuery request, CancellationToken cancellationToken)
    {
        var servicesProviders = await _providerService.GetProvidersAsync(request.PageSize);
        if (servicesProviders == null)
        {
            throw new Exception("No service providers found");
        }
        return servicesProviders.ToProviderOutputList();
    }
}

public class GetProviderHandler : IRequestHandler<GetProviderQuery, ProviderOutput>
{
    private readonly IProviderServicesService _providerService;

    public GetProviderHandler(IProviderServicesService providerService)
    {
        _providerService = providerService;
    }

    public async Task<ProviderOutput> Handle(GetProviderQuery request, CancellationToken cancellationToken)
    {
        var servicesProvider = await _providerService.GetProviderAsync(request.CustomerId);
        if (servicesProvider == null)
        {
            throw new ArgumentNullException(nameof(servicesProvider), "Service provider not found.");
        }
        return servicesProvider.ToProviderOutput();
    }
}

public class GetProviderByPhoneNoHandler : IRequestHandler<GetProviderByPhoneNoRequest, ProviderOutput?>
{
    private readonly IProviderServicesService _providerService;

    public GetProviderByPhoneNoHandler(IProviderServicesService providerService)
    {
        _providerService = providerService;
    }

    public async Task<ProviderOutput?> Handle(GetProviderByPhoneNoRequest request, CancellationToken cancellationToken)
    {
        var provider = await _providerService.GetProviderByPhoneNumberAsync(request.PhoneNo);
        return provider?.ToProviderOutput();
    }
}

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
            throw new Exception("No services found for the provider");
        }
        return providerServices.ToProviderServiceOutputList();
    }
}
