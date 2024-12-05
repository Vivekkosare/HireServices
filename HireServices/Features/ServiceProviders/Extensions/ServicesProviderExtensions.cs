using HireServices.Domain.Extensions;
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
                    .WithCategory(serviceInput.Category)
                    .Build();
                }).ToList())
                .Build();
        }
    }
}
