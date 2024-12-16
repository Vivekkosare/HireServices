using HireServices.Features.ServiceProviders.DTOs;
using HireServices.Features.ServiceProviders.Extensions;
using HireServices.Features.ServiceProviders.Services;
using MediatR;

namespace HireServices.Features.ServiceProviders.Queries.GetServicesProvider
{
    public class GetProviderHandler : IRequestHandler<GetProviderQuery, ProviderOutput>
    {
        private readonly ISProviderService _providerService;

        public GetProviderHandler(ISProviderService providerService)
        {
            _providerService = providerService;
        }
        public async Task<ProviderOutput> Handle(GetProviderQuery request, CancellationToken cancellationToken)
        {
            var servicesProvider = await _providerService.GetProviderAsync(request.customerId);
            if (servicesProvider == null)
            {
                throw new ArgumentNullException(nameof(servicesProvider), "Service provider not found.");
            }
            return servicesProvider.ToServiceProviderOutput();
        }
    }
}
