using HireServices.Features.ServiceProviders.DTOs;
using HireServices.Features.ServiceProviders.Extensions;
using HireServices.Features.ServiceProviders.Services;
using MediatR;

namespace HireServices.Features.ServiceProviders.Queries.GetProvider
{
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
}
