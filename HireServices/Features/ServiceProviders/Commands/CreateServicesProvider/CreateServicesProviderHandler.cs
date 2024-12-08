using HireServices.Features.ServiceProviders.DTOs;
using HireServices.Features.ServiceProviders.Extensions;
using HireServices.Features.ServiceProviders.Services;
using MediatR;

namespace HireServices.Features.ServiceProviders.Commands.CreateServicesProvider
{
    public class CreateServicesProviderHandler : IRequestHandler<CreateServicesProviderCommand, ServicesProviderOutput>
    {
        private readonly IServicesProviderService _providerService;

        public CreateServicesProviderHandler(IServicesProviderService providerService)
        {
            _providerService = providerService;
        }
        public async Task<ServicesProviderOutput> Handle(CreateServicesProviderCommand request, CancellationToken cancellationToken)
        {
            var servicesProvider = await _providerService.CreateServicesProviderAsync(request.Input.ToServiceProvider());
            if (servicesProvider == null)
            {
                throw new Exception("Error creating services provider");
            }
            return servicesProvider.ToServiceProviderOutput();
        }
    }
}
