using HireServices.Common.Extensions;
using HireServices.Features.ServiceProviders.Domain.Builders;
using HireServices.Features.ServiceProviders.Domain.Entities;
using HireServices.Features.ServiceProviders.DTOs;
using HireServices.Features.ServiceProviders.Inputs;

namespace HireServices.Features.ServiceProviders.Extensions
{
    public static class ProviderExtensions
    {
        public static Provider ToServiceProvider(this ProviderInput serviceProviderInput)
        {
            //var services = serviceProviderInput.ServicesInput.Select(serviceInput =>
            //    {
            //        return new ServicesProviderService.ServicesProviderServiceBuilder()
            //        .WithName(serviceInput.Name)
            //        .WithDescription(serviceInput.Description)
            //        .WithPrice(serviceInput.Price)
            //        .WithDuration(serviceInput.Duration)
            //        .WithCategory(serviceInput.CategoryInput)
            //        .Build();
            //    }).ToList();
            var serviceTags = serviceProviderInput.ServicesInput.Select(s => s.Name);
            var serviceCategories = serviceProviderInput.ServicesInput.Select(sp => sp.CategoryInput.Name);

            return new ProviderBuilder()
                .WithContactInfo(serviceProviderInput.ContactInfoInput.ToContactInfo())
                .WithAddress(serviceProviderInput.AddressInput.ToAddress())
                .WithServiceTags(serviceTags)
                .WithServiceCategories(serviceCategories)
                .WithHighlightedServices(serviceProviderInput.ServicesInput.ToProviderServices())
                .WithAverageRating(default)
                .Build();
        }

        public static ProviderOutput ToProviderOutput(this Provider serviceProvider)
        {
            return new ProviderOutputBuilder()
                .WithId(serviceProvider.Id)
                .WithContactInfoOutput(serviceProvider.ContactInfo)
                .WithAddressOutput(serviceProvider.Address)
                .WithServiceTags(serviceProvider.ServiceTags)
                .WithServiceCategories(serviceProvider.ServiceCategories)
                .WithHighlightedServices(serviceProvider)
                .WithAge(serviceProvider.ContactInfo.DateOfBirth)
                .WithCreatedAt(serviceProvider.CreatedAt)
                .WithUpdatedAt(serviceProvider.UpdatedAt)
                .Build();
        }

        public static List<ProviderOutput> ToProviderOutputList(this List<Provider> providers)
        {
            return providers.Select(provider => provider.ToProviderOutput()).ToList();
        }

        public static List<ProviderService> ToProviderServices(this List<ProviderServiceInput> providerServicesInput)
        {
            return providerServicesInput.Select(providerServiceInput =>
            {
                return new ProviderServiceBuilder()
                    //.WithId(providerServiceInput.Id is null ? null : providerServiceInput.Id)
                    .WithName(providerServiceInput.Name)
                    .WithDescription(providerServiceInput.Description)
                    .WithPrice(providerServiceInput.Price)
                    .WithCurrency(providerServiceInput.Currency)
                    .WithDuration(providerServiceInput.Duration)
                    .WithCategory(providerServiceInput.CategoryInput)
                    .Build();
            }).ToList();
        }

        public static List<ProviderServiceOutput> ToProviderServiceOutputList(this List<ProviderService> providerServices)
        {
            return providerServices.Select(ps =>
                new ProviderServiceOutputBuilder()
                .WithId(ps.Id)
                .WithProviderId(ps.ProviderId)
                .WithName(ps.Name)
                .WithDescription(ps.Description)
                .WithPrice(ps.Price)
                .WithCurrency(ps.Currency)
                .WithDuration(ps.Duration)
                .WithCategory(ps.Category)
                .WithCreatedAt(ps.CreatedAt)
                .WithUpdatedAt(ps.UpdatedAt)
                .Build()).ToList();
        }
    }
}
