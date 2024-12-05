using HireServices.Features.ServiceProviders.Domain.AggregateRoots;

namespace HireServices.Features.ServiceProviders.Services
{
    public interface IServicesProviderService
    {
        public Task<ServicesProvider> GetServicesProvidersAsync();
        public Task<ServicesProvider> GetServicesProviderAsync(Guid serviceProviderId);
        public Task<ServicesProvider> CreateServicesProviderAsync(ServicesProvider servicesProvider);
        public Task<ServicesProvider> UpdateServicesProviderAsync(Guid serviceProviderId, ServicesProvider servicesProvider);
        public Task DeleteServicesProviderAsync(Guid serviceProviderId);
    }
}
