using HireServices.Features.ServiceProviders.DTOs;
using HireServices.Features.ServiceProviders.Extensions;
using HireServices.Features.ServiceProviders.Services;
using MediatR;

namespace HireServices.Features.ServiceProviders.Queries.GetProviders
{
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
}
