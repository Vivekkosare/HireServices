using HireServices.Features.Customers.GraphQL.Queries;
using HireServices.Features.ServiceProviders.DTOs;
using HireServices.Features.ServiceProviders.Queries;
using HireServices.Features.ServiceProviders.Queries.GetServicesProvider;
using HireServices.Features.ServiceProviders.Queries.GetServicesProviders;
using MediatR;

namespace HireServices.Features.ServiceProviders.GraphQL.Query
{
    [ExtendObjectType(Name = "Query")]
    public class ProviderQueryExtension : ProviderQuery
    {

    }
    public class Query
    {
        public string Hello() => "Hello";
    }
    public class ProviderQuery
    {
        public async Task<List<ProviderOutput>> GetServicesProviders([Service] IMediator mediator, int pageSize = 10)
        {
            return await mediator.Send(new GetProvidersQuery(pageSize));
        }

        public async Task<ProviderOutput> GetServicesProvider([Service] IMediator mediator, Guid servicesProviderId)
        {
            return await mediator.Send(new GetProviderQuery(servicesProviderId));
        }
    }
}
