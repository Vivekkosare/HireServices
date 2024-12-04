using HireServices.Features.ServiceProviders.Domain.AggregateRoots;
using HireServices.Features.ServiceProviders.GraphQL.Inputs;

namespace HireServices.Features.Customers.Extensions
{
    public static class ServiceExtensions
    {
        public static Service ToService(ServiceInput serviceInput)
        {
            return new Service(serviceInput.Name, serviceInput.Description, serviceInput.Price, serviceInput.Duration, serviceInput.Category);
        }
    }
}
