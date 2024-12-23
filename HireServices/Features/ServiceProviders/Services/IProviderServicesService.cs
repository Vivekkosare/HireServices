﻿using HireServices.Features.ServiceProviders.Domain.AggregateRoots;

namespace HireServices.Features.ServiceProviders.Services
{
    public interface IProviderServicesService
    {
        Task<List<Provider>> GetProvidersAsync(int pageSize);
        Task<Provider?> GetProviderAsync(Guid serviceProviderId);
        Task<Provider> CreateProviderAsync(Provider servicesProvider);
        Task<Provider> UpdateProviderAsync(Guid serviceProviderId, Provider servicesProvider);
        Task<bool> DeleteProviderAsync(Guid serviceProviderId);

        Task<ProviderService> CreateProviderServiceAsync(ProviderService providerService);
        Task<ProviderService> GetProviderServiceAsync(Guid providerServiceId);
        Task<List<ProviderService>> GetProviderServicesByProviderIdAsync(Guid providerId);
    }
}
