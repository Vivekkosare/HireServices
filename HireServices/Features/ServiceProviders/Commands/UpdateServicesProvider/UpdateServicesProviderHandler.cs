using HireServices.Features.ServiceProviders.DTOs;
using HireServices.Features.ServiceProviders.Extensions;
using HireServices.Features.ServiceProviders.Services;
using MediatR;

namespace HireServices.Features.ServiceProviders.Commands.UpdateServicesProvider
{
    public class UpdateServicesProviderHandler : IRequestHandler<UpdateServicesProviderCommand, ServicesProviderOutput>
    {
        private readonly IServicesProviderService _providerService;

        public UpdateServicesProviderHandler(IServicesProviderService providerService)
        {
            _providerService = providerService;
        }
        public async Task<ServicesProviderOutput> Handle(UpdateServicesProviderCommand request, CancellationToken cancellationToken)
        {
            var serviceProvider = await _providerService.GetServicesProviderAsync(request.serviceProviderId);
            if (serviceProvider == null)
            {
                throw new Exception("Services provider not found to update");
            }
            var servicesProviderUpdated = await _providerService.UpdateServicesProviderAsync(request.serviceProviderId, serviceProvider);
            if (servicesProviderUpdated == null)
            {
                throw new Exception("Error updating services provider");
            }
            return servicesProviderUpdated.ToServiceProviderOutput();
        }
    }
}
