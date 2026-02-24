using HireServices.Features.ServiceProviders.DTOs;
using HireServices.Features.ServiceProviders.Inputs;
using HireServices.Features.ServiceProviders.Mutations.Handlers;
using HotChocolate.Authorization;
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
        // Requires a valid Firebase Bearer token. HotChocolate will return
        // an AUTH_NOT_AUTHENTICATED error before the resolver runs if missing.
        [Authorize]
        public async Task<ProviderOutput> CreateProvider([Service] IMediator mediator, ProviderInput providerInput)
        {
            var providerResponse = await mediator.Send(new CreateProviderCommand(providerInput));
            return providerResponse;
        }

        [Authorize]
        public async Task<ProviderOutput> UpdateProvider([Service] IMediator mediator, Guid servicesProviderId, ProviderUpdateInput providerUpdateInput)
        {
            return await mediator.Send(new UpdateProviderCommand(servicesProviderId, providerUpdateInput));
        }

        [Authorize]
        public async Task DeleteProvider([Service] IMediator mediator, Guid providerId)
        {
            await mediator.Send(new DeleteProviderCommand(providerId));
        }
    }
}
