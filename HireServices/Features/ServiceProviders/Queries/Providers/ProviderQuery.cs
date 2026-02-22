using HireServices.Features.ServiceProviders.DTOs;
using HireServices.Features.ServiceProviders.Queries.Providers.Handlers;
using MediatR;

namespace HireServices.Features.ServiceProviders.Queries
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
            return await mediator.Send(new GetProviderByPhoneNoQuery(phoneNo));
        }

        public async Task<bool> ProviderExistsByPhoneNo([Service] IMediator mediator, [GraphQLNonNullType] string phoneNo)
        {
            return await mediator.Send(new ProviderExistsByPhoneNoQuery(phoneNo));
        }

        public async Task<List<ProviderServiceOutput>> GetProviderServicesAsync([Service] IMediator mediator, [GraphQLNonNullType] Guid providerId)
        {
            return await mediator.Send(new GetProviderServicesQuery(providerId));
        }

    }
}
