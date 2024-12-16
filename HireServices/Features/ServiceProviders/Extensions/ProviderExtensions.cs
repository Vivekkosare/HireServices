using HireServices.Domain.Extensions;
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
            //        return new Domain.AggregateRoots.ServicesProviderService.ServicesProviderServiceBuilder()
            //        .WithName(serviceInput.Name)
            //        .WithDescription(serviceInput.Description)
            //        .WithPrice(serviceInput.Price)
            //        .WithDuration(serviceInput.Duration)
            //        .WithCategory(serviceInput.CategoryInput)
            //        .Build();
            //    }).ToList();
            var serviceTags = serviceProviderInput.ServicesInput.Select(s => s.Name);
            var serviceCategories = serviceProviderInput.ServicesInput.Select(sp => sp.CategoryInput.Name);

            return new Domain.AggregateRoots.Provider.ProviderBuilder()
                .WithContactInfo(serviceProviderInput.ContactInfoInput.ToContactInfo())
                .WithAddress(serviceProviderInput.AddressInput.ToAddress())
                .WithServiceTags(serviceTags)
                .WithServiceCategories(serviceCategories)
                .Build();
        }

        public static ProviderOutput ToServiceProviderOutput(this Domain.AggregateRoots.Provider serviceProvider)
        {
            return new ProviderOutput.ProviderOutputBuilder()
                .WithId(serviceProvider.Id)
                .WithContactInfoOutput(serviceProvider.ContactInfo)
                .WithAddressOutput(serviceProvider.Address)
                .WithServiceTags(serviceProvider.ServiceTags)
                .WithServiceCategories(serviceProvider.ServiceCategories)
                .WithCreatedAt(serviceProvider.CreatedAt)
                .WithUpdatedAt(serviceProvider.UpdatedAt)
                .Build();
        }

        public static List<ProviderOutput> ToServicesProviderOutputList(this List<Domain.AggregateRoots.Provider> serviceProviders)
        {
            return serviceProviders.Select(serviceProvider => serviceProvider.ToServiceProviderOutput()).ToList();
        }
    }
}
