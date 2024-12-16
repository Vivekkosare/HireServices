using HireServices.Features.ServiceProviders.Domain.AggregateRoots;

namespace HireServices.Features.ServiceProviders.Services
{
    public interface ISProviderService
    {
        public Task<List<Provider>> GetProvidersAsync(int pageSize);
        public Task<Provider?> GetProviderAsync(Guid serviceProviderId);
        public Task<Provider> CreateProviderAsync(Provider servicesProvider);
        public Task<Provider> UpdateProviderAsync(Guid serviceProviderId, Provider servicesProvider);
        public Task<bool> DeleteProviderAsync(Guid serviceProviderId);
    }
}
