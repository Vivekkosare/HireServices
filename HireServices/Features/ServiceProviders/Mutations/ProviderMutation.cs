﻿using HireServices.Features.ServiceProviders.DTOs;
using HireServices.Features.ServiceProviders.Inputs;
using HireServices.Features.ServiceProviders.Mutations.Handlers;
using MediatR;

namespace HireServices.Features.ServiceProviders.Mutations
{
    [ExtendObjectType(Name = "Mutation")]
    public class ProviderMutationExtension : ProviderMutation
    {
    }
    public class Mutation
    {
        public string Echo(string message) => message;
    }
    public class ProviderMutation
    {
        public async Task<ProviderOutput> CreateProvider([Service] IMediator mediator, ProviderInput providerInput)
        {
            var providerResponse = await mediator.Send(new CreateProviderCommand(providerInput));
            return providerResponse;
        }
        public async Task<ProviderOutput> UpdateProvider([Service] IMediator mediator, Guid servicesProviderId, ProviderUpdateInput providerUpdateInput)
        {
            return await mediator.Send(new UpdateProviderCommand(servicesProviderId, providerUpdateInput));
        }
        public async Task DeleteProvider([Service] IMediator mediator, Guid providerId)
        {
            await mediator.Send(new DeleteProviderCommand(providerId));
        }
    }
}
