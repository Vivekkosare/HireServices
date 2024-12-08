using HireServices.Features.ServiceProviders.DTOs;
using HireServices.Features.ServiceProviders.Extensions;
using HireServices.Features.ServiceProviders.Services;
using MediatR;

namespace HireServices.Features.ServiceProviders.Queries.GetServicesProviders
{
    public class GetServicesProvidersHandler : IRequestHandler<GetServicesProvidersQuery, List<ServicesProviderOutput>>
    {
        private readonly IServicesProviderService _providerService;

        public GetServicesProvidersHandler(IServicesProviderService providerService)
        {
            _providerService = providerService;
        }
        public async Task<List<ServicesProviderOutput>> Handle(GetServicesProvidersQuery request, CancellationToken cancellationToken)
        {
            var servicesProviders = await _providerService.GetServicesProvidersAsync(request.PageSize);
            if (servicesProviders == null)
            {
                throw new Exception("No service providers found");
            }
            return servicesProviders.ToServicesProviderOutputList();
        }
    }
}
