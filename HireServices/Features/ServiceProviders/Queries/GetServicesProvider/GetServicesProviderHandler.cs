using HireServices.Features.ServiceProviders.DTOs;
using HireServices.Features.ServiceProviders.Extensions;
using HireServices.Features.ServiceProviders.Services;
using MediatR;

namespace HireServices.Features.ServiceProviders.Queries.GetServicesProvider
{
    public class GetServicesProviderHandler : IRequestHandler<GetServicesProviderQuery, ServicesProviderOutput>
    {
        private readonly IServicesProviderService _providerService;

        public GetServicesProviderHandler(IServicesProviderService providerService)
        {
            _providerService = providerService;
        }
        public async Task<ServicesProviderOutput> Handle(GetServicesProviderQuery request, CancellationToken cancellationToken)
        {
            var servicesProvider = await _providerService.GetServicesProviderAsync(request.customerId);
            if (servicesProvider == null)
            {
                throw new ArgumentNullException(nameof(servicesProvider), "Service provider not found.");
            }
            return servicesProvider.ToServiceProviderOutput();
        }
    }
}
