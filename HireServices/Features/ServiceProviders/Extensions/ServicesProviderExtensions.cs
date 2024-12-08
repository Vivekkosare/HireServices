using HireServices.Domain.Extensions;
using HireServices.Features.ServiceProviders.DTOs;
using HireServices.Features.ServiceProviders.GraphQL.Inputs;

namespace HireServices.Features.ServiceProviders.Extensions
{
    public static class ServicesProviderExtensions
    {
        public static Domain.AggregateRoots.ServicesProvider ToServiceProvider(this ServicesProviderInput serviceProviderInput)
        {
            
            return new Domain.AggregateRoots.ServicesProvider.ServicesProviderBuilder()
                .WithContactInfo(serviceProviderInput.ContactInfoInput.ToContactInfo())
                .WithAddress(serviceProviderInput.AddressInput.ToAddress())
                .WithServices(serviceProviderInput.ServicesInput.Select(serviceInput =>
                {
                    return new Domain.AggregateRoots.Service.ServiceBuilder()
                    .WithName(serviceInput.Name)
                    .WithDescription(serviceInput.Description)
                    .WithPrice(serviceInput.Price)
                    .WithDuration(serviceInput.Duration)
                    .WithCategory(serviceInput.CategoryInput)
                    .Build();
                }).ToList())
                .Build();
        }

        public static ServicesProviderOutput ToServiceProviderOutput(this Domain.AggregateRoots.ServicesProvider serviceProvider)
        {
            return new ServicesProviderOutput.ServicesProviderOutputBuilder()
                .WithId(serviceProvider.Id)
                .WithContactInfoOutput(serviceProvider.ContactInfo)
                .WithAddressOutput(serviceProvider.Address)
                .WithServicesOutput(serviceProvider.Services)
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
