using HireServices.Features.ServiceProviders.Domain.AggregateRoots;

namespace HireServices.Features.ServiceProviders.Services
{
    public interface IServicesProviderService
    {
        public Task<List<ServicesProvider>> GetServicesProvidersAsync(int pageSize);
        public Task<ServicesProvider?> GetServicesProviderAsync(Guid serviceProviderId);
        public Task<ServicesProvider> CreateServicesProviderAsync(ServicesProvider servicesProvider);
        public Task<ServicesProvider> UpdateServicesProviderAsync(Guid serviceProviderId, ServicesProvider servicesProvider);
        public Task<bool> DeleteServicesProviderAsync(Guid serviceProviderId);
    }
}
