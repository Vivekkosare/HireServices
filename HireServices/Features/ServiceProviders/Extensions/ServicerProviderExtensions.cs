using HireServices.Domain.Extensions;
using HireServices.Features.ServiceProviders.GraphQL.Inputs;

namespace HireServices.Features.ServiceProviders.Extensions
{
    public static class ServicerProviderExtensions
    {
        public static ServiceProvider ToServiceProvider(this ServiceProviderInput serviceProviderInput)
        {
            return new Domain.AggregateRoots.ServiceProvider.ServiceProviderBuilder()
                .WithContactInfo(serviceProviderInput.ContactInfoInput.ToContactInfo())
                .WithAddress(serviceProviderInput.AddressInput.ToAddress())
                .WithServices(serviceProviderInput.ServicesInput.Select(serviceInput => serviceInput.).ToList())
                .Build();
        }
    }
}
