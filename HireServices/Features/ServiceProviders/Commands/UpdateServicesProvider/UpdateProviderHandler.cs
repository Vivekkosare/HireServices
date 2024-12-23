using HireServices.Features.ServiceProviders.DTOs;
using HireServices.Features.ServiceProviders.Extensions;
using HireServices.Features.ServiceProviders.Services;
using MediatR;

namespace HireServices.Features.ServiceProviders.Commands.UpdateServicesProvider
{
    public class UpdateProviderHandler : IRequestHandler<UpdateProviderCommand, ProviderOutput>
    {
        private readonly IProviderServicesService _providerService;

        public UpdateProviderHandler(IProviderServicesService providerService)
        {
            _providerService = providerService;
        }
        public async Task<ProviderOutput> Handle(UpdateProviderCommand request, CancellationToken cancellationToken)
        {
            var provider = await _providerService.GetProviderAsync(request.ProviderId);
            if (provider == null)
            {
                throw new Exception("Services provider not found to update");
            }
            var providerUpdated = await _providerService.UpdateProviderAsync(request.ProviderId, provider);
            if (providerUpdated == null)
            {
                throw new Exception("Error updating services provider");
            }
            return providerUpdated.ToProviderOutput();
        }
    }
}
