using HireServices.Domain.Common;
using HireServices.Features.ServiceProviders.Commands;
using HireServices.Features.ServiceProviders.Commands.CreateServicesProvider;
using HireServices.Features.ServiceProviders.Commands.DeleteServicesProvider;
using HireServices.Features.ServiceProviders.Commands.UpdateServicesProvider;
using HireServices.Features.ServiceProviders.DTOs;
using HireServices.Features.ServiceProviders.GraphQL.Inputs;
using MediatR;

namespace HireServices.Features.ServiceProviders.GraphQL.Mutations
{
    [ExtendObjectType(Name = "Mutation")]
    public class ProviderMutationExtension: ProviderMutation
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
        public async Task<ProviderOutput> UpdateProvider([Service] IMediator mediator, Guid servicesProviderId, ProviderInput providerInput)
        {
            return await mediator.Send(new UpdateProviderCommand(servicesProviderId, providerInput));
        }
        public async Task DeleteProvider([Service] IMediator mediator, Guid providerId)
        {
            await mediator.Send(new DeleteProviderCommand(providerId));
        }
    }
}
