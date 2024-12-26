using HireServices.Features.ServiceProviders.Data;
using HireServices.Features.ServiceProviders.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;

namespace HireServices.Features.ServiceProviders.Services
{
    public class ProviderServicesService : IProviderServicesService
    {
        private readonly ProviderDbContext _providerDbContext;

        public ProviderServicesService(ProviderDbContext providerDbContext)
        {
            _providerDbContext = providerDbContext;
        }
        public async Task<Provider> CreateProviderAsync(Provider servicesProvider)
        {
            var servicesProviderCreated = await _providerDbContext.Providers.AddAsync(servicesProvider);
            await SaveChangesAsync();
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
            await SaveChangesAsync();
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
            await SaveChangesAsync();
            return servicesProvider;
        }

        /*************************----------------PROVIDER SERVICES--------------**************************/

        public async Task<ProviderService> CreateProviderServiceAsync(ProviderService providerService)
        {
            var providerServiceCreated = await _providerDbContext.ProviderServices.AddAsync(providerService);
            await SaveChangesAsync();
            return providerServiceCreated.Entity;
        }
        public async Task<ProviderService> GetProviderServiceAsync(Guid providerServiceId)
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

        public async Task<List<ProviderService>> GetProviderServicesByProviderIdAsync(Guid providerId)
        {
            var providerServices = await _providerDbContext.ProviderServices.Where(x => x.ProviderId == providerId).ToListAsync();
            if (providerServices is null)
            {
                throw new ArgumentNullException(nameof(providerServices), "Provider services not found.");
            }
            return providerServices;
        }
    }
}
