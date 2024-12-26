using HireServices.Domain.Extensions;
using HireServices.Features.ServiceProviders.Domain.AggregateRoots;
using HireServices.Features.ServiceProviders.DTOs;
using HireServices.Features.ServiceProviders.GraphQL.Inputs;

namespace HireServices.Features.ServiceProviders.Extensions
{
    public static class ProviderExtensions
    {
        public static Domain.AggregateRoots.Provider ToServiceProvider(this ProviderInput serviceProviderInput)
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

            return new Provider.ProviderBuilder()
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
            return new ProviderOutput.ProviderOutputBuilder()
                .WithId(serviceProvider.Id)
                .WithContactInfoOutput(serviceProvider.ContactInfo)
                .WithAddressOutput(serviceProvider.Address)
                .WithServiceTags(serviceProvider.ServiceTags)
                .WithServiceCategories(serviceProvider.ServiceCategories)
                .WithHighlightedServices(serviceProvider.HighlightedServices)
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
                return new ProviderService.ProviderServiceBuilder()
                    .WithName(providerServiceInput.Name)
                    .WithDescription(providerServiceInput.Description)
                    .WithPrice(providerServiceInput.Price)
                    .WithDuration(providerServiceInput.Duration)
                    .WithCategory(providerServiceInput.CategoryInput)
                    .Build();
            }).ToList();
        }

        public static List<ProviderServiceOutput> ToProviderServiceOutputList(this List<ProviderService> providerServices)
        {
            return providerServices.Select(ps =>
                new ProviderServiceOutput.ProviderServiceOutputBuilder()
                .WithId(ps.Id.GetValueOrDefault())  
                .WithName(ps.Name)
                .WithDescription(ps.Description)
                .WithPrice(ps.Price)
                .WithDuration(ps.Duration)
                .WithCategory(ps.Category)
                .WithCreatedAt(ps.CreatedAt)
                .WithUpdatedAt(ps.UpdatedAt)
                .Build()).ToList();
        }
    }
}
