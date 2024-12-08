using HireServices.Features.ServiceProviders.DTOs;
using HireServices.Features.ServiceProviders.Queries;
using HireServices.Features.ServiceProviders.Queries.GetServicesProvider;
using HireServices.Features.ServiceProviders.Queries.GetServicesProviders;
using MediatR;

namespace HireServices.Features.ServiceProviders.GraphQL.Query
{
    public class Query
    {
        public string Hello() => "Hello";
    }
    public class ServicesProviderQuery
    {
        public async Task<List<ServicesProviderOutput>> GetServicesProviders([Service] IMediator mediator, int pageSize = 10)
        {
            return await mediator.Send(new GetServicesProvidersQuery(pageSize));
        }

        public async Task<ServicesProviderOutput> GetServicesProvider([Service] IMediator mediator, Guid servicesProviderId)
        {
            return await mediator.Send(new GetServicesProviderQuery(servicesProviderId));
        }
    }
}
