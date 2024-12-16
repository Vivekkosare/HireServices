using HireServices.Features.ServiceProviders.Services;
using MediatR;

namespace HireServices.Features.ServiceProviders.Commands.DeleteServicesProvider
{
    public class DeleteProviderHandler : IRequestHandler<DeleteProviderCommand, bool>
    {
        private readonly ISProviderService _providerService;

        public DeleteProviderHandler(ISProviderService providerService)
        {
            _providerService = providerService;
        }
        public async Task<bool> Handle(DeleteProviderCommand request, CancellationToken cancellationToken)
        {
            var serviceProviderDeleted = await _providerService.DeleteProviderAsync(request.servicesProviderId);
            if (!serviceProviderDeleted)
            {
                throw new Exception("Error deleting services provider");
            }
            return serviceProviderDeleted;
        }
    }
}
