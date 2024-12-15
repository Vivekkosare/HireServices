using HireServices.Domain.Extensions;
using HireServices.Features.ServiceProviders.DTOs;
using HireServices.Features.ServiceProviders.GraphQL.Inputs;

namespace HireServices.Features.ServiceProviders.Extensions
{
    public static class ServicesProviderExtensions
    {
        public static Domain.AggregateRoots.ServicesProvider ToServiceProvider(this ServicesProviderInput serviceProviderInput)
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

            return new Domain.AggregateRoots.ServicesProvider.ServicesProviderBuilder()
                .WithContactInfo(serviceProviderInput.ContactInfoInput.ToContactInfo())
                .WithAddress(serviceProviderInput.AddressInput.ToAddress())
                .WithServiceTags(serviceTags)
                .Build();
        }

        public static ServicesProviderOutput ToServiceProviderOutput(this Domain.AggregateRoots.ServicesProvider serviceProvider)
        {
            return new ServicesProviderOutput.ServicesProviderOutputBuilder()
                .WithId(serviceProvider.Id)
                .WithContactInfoOutput(serviceProvider.ContactInfo)
                .WithAddressOutput(serviceProvider.Address)
                .WithServiceTags(serviceProvider.ServiceTags)
                .WithCreatedAt(serviceProvider.CreatedAt)
                .WithUpdatedAt(serviceProvider.UpdatedAt)
                .Build();
        }

        public static List<ServicesProviderOutput> ToServicesProviderOutputList(this List<Domain.AggregateRoots.ServicesProvider> serviceProviders)
        {
            return serviceProviders.Select(serviceProvider => serviceProvider.ToServiceProviderOutput()).ToList();
        }
    }
}
