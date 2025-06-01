using HireServices.Features.ServiceProviders.Domain.Entities;
using HireServices.Features.ServiceProviders.Domain.Builders;
using HireServices.Features.ServiceProviders.Inputs;

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
                .WithCurrency(serviceInput.Currency)
                .WithDescription(serviceInput.Description)
                .WithDuration(serviceInput.Duration)
                .WithName(serviceInput.Name)
                .Build();
        }
    }
}
