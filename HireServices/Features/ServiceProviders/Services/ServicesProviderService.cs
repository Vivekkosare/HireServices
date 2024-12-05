using HireServices.Features.ServiceProviders.Data;
using HireServices.Features.ServiceProviders.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;

namespace HireServices.Features.ServiceProviders.Services
{
    public class ServicesProviderService : IServicesProviderService
    {
        private readonly ServicesProviderDbContext _providerDbContext;

        public ServicesProviderService(ServicesProviderDbContext providerDbContext)
        {
            _providerDbContext = providerDbContext;
        }
        public async Task<ServicesProvider> CreateServicesProviderAsync(ServicesProvider servicesProvider)
        {
            var servicesProviderCreated = await _providerDbContext.ServiceProviders.AddAsync(servicesProvider);
            await _providerDbContext.SaveChangesAsync();
            return servicesProviderCreated.Entity;
        }

        public async Task DeleteServicesProviderAsync(Guid serviceProviderId)
        {
            var servicesProvider = await GetServicesProviderAsync(serviceProviderId);
            _providerDbContext.ServiceProviders.Remove(servicesProvider);
            await _providerDbContext.SaveChangesAsync();
        }

        public async Task<ServicesProvider?> GetServicesProviderAsync(Guid serviceProviderId)
        {
            return await _providerDbContext.ServiceProviders.FindAsync(serviceProviderId);
        }

        public async Task<List<ServicesProvider>> GetServicesProvidersAsync(int pageSize)
        {
            return await _providerDbContext.ServiceProviders.Take(pageSize).ToListAsync();
        }

        public async Task<ServicesProvider> UpdateServicesProviderAsync(Guid serviceProviderId, ServicesProvider servicesProvider)
        {
            _providerDbContext.ServiceProviders.Update(servicesProvider);
            await _providerDbContext.SaveChangesAsync();
            return servicesProvider;
        }
    }
}
