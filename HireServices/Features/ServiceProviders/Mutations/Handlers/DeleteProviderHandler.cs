using HireServices.Features.ServiceProviders.Data;
using HireServices.Features.ServiceProviders.Services;
using MediatR;

namespace HireServices.Features.ServiceProviders.Mutations.Handlers
{
    public record DeleteProviderCommand(Guid ProviderId) : IRequest<bool>
    {
    }
    public class DeleteProviderHandler : IRequestHandler<DeleteProviderCommand, bool>
    {
        private readonly IProviderServicesService _providerService;
        private readonly ProviderDbContext _providerDbContext;

        public DeleteProviderHandler(IProviderServicesService providerService,
            ProviderDbContext providerDbContext)
        {
            _providerService = providerService;
            _providerDbContext = providerDbContext;
        }
        public async Task<bool> Handle(DeleteProviderCommand request, CancellationToken cancellationToken)
        {
            bool providerDeleted = false;
            using (var transaction = await _providerDbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var providerServices = await _providerService.GetProviderServicesByProviderIdAsync(request.ProviderId);
                    if (providerServices is null || providerServices.Count == 0)
                    {
                        throw new Exception($"Services not found for providerId: {request.ProviderId}");
                    }

                    providerDeleted = await _providerService.DeleteProviderAsync(request.ProviderId);
                    if (!providerDeleted)
                    {
                        throw new Exception("Error deleting services provider");
                    }
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    return false;
                }
            }

            return providerDeleted;
        }
    }
}
