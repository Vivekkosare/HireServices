using HireServices.Features.ServiceProviders.Services;
using MediatR;

namespace HireServices.Features.ServiceProviders.Commands.DeleteServicesProvider
{
    public class DeleteServicesProviderHandler : IRequestHandler<DeleteServicesProviderCommand, bool>
    {
        private readonly IServicesProviderService _providerService;

        public DeleteServicesProviderHandler(IServicesProviderService providerService)
        {
            _providerService = providerService;
        }
        public async Task<bool> Handle(DeleteServicesProviderCommand request, CancellationToken cancellationToken)
        {
            var serviceProviderDeleted = await _providerService.DeleteServicesProviderAsync(request.servicesProviderId);
            if (!serviceProviderDeleted)
            {
                throw new Exception("Error deleting services provider");
            }
            return serviceProviderDeleted;
        }
    }
}
