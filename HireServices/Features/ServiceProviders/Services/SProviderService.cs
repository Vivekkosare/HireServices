using HireServices.Features.ServiceProviders.Data;
using HireServices.Features.ServiceProviders.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;

namespace HireServices.Features.ServiceProviders.Services
{
    public class SProviderService : ISProviderService
    {
        private readonly ProviderDbContext _providerDbContext;

        public SProviderService(ProviderDbContext providerDbContext)
        {
            _providerDbContext = providerDbContext;
        }
        public async Task<Provider> CreateProviderAsync(Provider servicesProvider)
        {
            var servicesProviderCreated = await _providerDbContext.Providers.AddAsync(servicesProvider);
            return servicesProviderCreated.Entity;
        }

        public async Task<bool> DeleteProviderAsync(Guid serviceProviderId)
        {
            var servicesProvider = await GetProviderAsync(serviceProviderId);
            if (servicesProvider == null)
            {
                return false;
            }
            _providerDbContext.Providers.Remove(servicesProvider);
            return true;
        }

        public async Task<Provider?> GetProviderAsync(Guid serviceProviderId)
        {
            return await _providerDbContext.Providers.FindAsync(serviceProviderId);
        }

        public async Task<List<Provider>> GetProvidersAsync(int pageSize)
        {
            return await _providerDbContext.Providers.Take(pageSize).ToListAsync();
        }

        public async Task<Provider> UpdateProviderAsync(Guid serviceProviderId, Provider servicesProvider)
        {
            _providerDbContext.Providers.Update(servicesProvider);
            return servicesProvider;
        }

        public async Task<ProviderService> CreateProviderServiceAsync(ProviderService providerService)
        {
            var providerServiceCreated = await _providerDbContext.ProviderServices.AddAsync(providerService);
            return providerServiceCreated.Entity;
        }
        public async Task<ProviderService> GetProviderServicesAsync(Guid providerServiceId)
        {
            var providerService = await _providerDbContext.ProviderServices.FindAsync(providerServiceId);
            if(providerService is null)
            {
                throw new ArgumentNullException(nameof(providerService), "Provider service not found.");
            }
            return providerService;
        }

        async Task SaveChangesAsync()
        {
            await _providerDbContext.SaveChangesAsync();
        }
    }
}
