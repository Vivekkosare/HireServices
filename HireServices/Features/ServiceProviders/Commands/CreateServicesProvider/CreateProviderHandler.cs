using HireServices.Features.ServiceProviders.DTOs;
using HireServices.Features.ServiceProviders.Extensions;
using HireServices.Features.ServiceProviders.Services;
using MediatR;

namespace HireServices.Features.ServiceProviders.Commands.CreateServicesProvider
{
    public class CreateProviderHandler : IRequestHandler<CreateProviderCommand, ProviderOutput>
    {
        private readonly ISProviderService _providerService;

        public CreateProviderHandler(ISProviderService providerService)
        {
            _providerService = providerService;
        }
        public async Task<ProviderOutput> Handle(CreateProviderCommand request, CancellationToken cancellationToken)
        {
            var servicesProvider = await _providerService.CreateProviderAsync(request.Input.ToServiceProvider());
            if (servicesProvider == null)
            {
                throw new Exception("Error creating services provider");
            }
            return servicesProvider.ToServiceProviderOutput();
        }
    }
}
