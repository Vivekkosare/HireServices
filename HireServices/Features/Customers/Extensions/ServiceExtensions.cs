using HireServices.Features.ServiceProviders.Domain.Entities;
using HireServices.Features.ServiceProviders.GraphQL.Inputs;
using HireServices.Features.ServiceProviders.Domain.Builders;

namespace HireServices.Features.Customers.Extensions
{
    public static class ServiceExtensions
    {
        public static ProviderService ToService(ProviderServiceInput serviceInput)
        {
            return new ProviderServiceBuilder()
                //.WithId(serviceInput.Id)
                .WithCategory(serviceInput.CategoryInput)
                .WithPrice(serviceInput.Price)
                .WithDescription(serviceInput.Description)
                .WithDuration(serviceInput.Duration)
                .WithName(serviceInput.Name)
                .Build();
        }
    }
}
