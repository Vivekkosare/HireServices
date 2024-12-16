using HireServices.Features.ServiceProviders.DTOs;
using HireServices.Features.ServiceProviders.Extensions;
using HireServices.Features.ServiceProviders.Services;
using MediatR;

namespace HireServices.Features.ServiceProviders.Commands.UpdateServicesProvider
{
    public class UpdateProviderHandler : IRequestHandler<UpdateProviderCommand, ProviderOutput>
    {
        private readonly ISProviderService _providerService;

        public UpdateProviderHandler(ISProviderService providerService)
        {
            _providerService = providerService;
        }
        public async Task<ProviderOutput> Handle(UpdateProviderCommand request, CancellationToken cancellationToken)
        {
            var serviceProvider = await _providerService.GetProviderAsync(request.serviceProviderId);
            if (serviceProvider == null)
            {
                throw new Exception("Services provider not found to update");
            }
            var servicesProviderUpdated = await _providerService.UpdateProviderAsync(request.serviceProviderId, serviceProvider);
            if (servicesProviderUpdated == null)
            {
                throw new Exception("Error updating services provider");
            }
            return servicesProviderUpdated.ToServiceProviderOutput();
        }
    }
}
