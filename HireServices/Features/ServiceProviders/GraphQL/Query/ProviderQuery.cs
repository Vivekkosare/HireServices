﻿using HireServices.Features.ServiceProviders.DTOs;
using HireServices.Features.ServiceProviders.Queries.GetProvider;
using HireServices.Features.ServiceProviders.Queries.GetProviders;
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
        public async Task<List<ProviderOutput>> GetProviders([Service] IMediator mediator, int pageSize = 10)
        {
            return await mediator.Send(new GetProvidersQuery(pageSize));
        }

        public async Task<ProviderOutput> GetProvider([Service] IMediator mediator, Guid servicesProviderId)
        {
            return await mediator.Send(new GetProviderQuery(servicesProviderId));
        }
    }
}
