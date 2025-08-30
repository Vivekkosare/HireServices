using HireServices.Features.ServiceProviders.DTOs;
using HireServices.Features.ServiceProviders.Query.Handlers;
using HireServices.Features.ServiceProviders.Query.Providers.Handlers;
using HireServices.Features.ServiceProviders.Query.ProviderServices.Handlers;
using MediatR;

namespace HireServices.Features.ServiceProviders.Query
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
        public async Task<List<ProviderOutput>> GetProviders([Service] IMediator mediator, int pageSize = 10)
        {
            return await mediator.Send(new GetProvidersQuery(pageSize));
        }

        public async Task<ProviderOutput> GetProvider([Service] IMediator mediator, Guid servicesProviderId)
        {
            return await mediator.Send(new GetProviderQuery(servicesProviderId));
        }

        public async Task<ProviderOutput?> GetProviderByPhoneNo([Service] IMediator mediator, [GraphQLNonNullType] string phoneNo)
        {
            return await mediator.Send(new GetProviderByPhoneNoRequest(phoneNo));
        }

        public async Task<List<ProviderServiceOutput>> GetProviderServicesAsync([Service] IMediator mediator, [GraphQLNonNullType] Guid providerId)
        {
            return await mediator.Send(new GetProviderServicesQuery(providerId));
        }

    }
}
