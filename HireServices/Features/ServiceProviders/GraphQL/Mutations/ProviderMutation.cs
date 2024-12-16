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
        public async Task<ProviderOutput> CreateServicesProvider([Service] IMediator mediator, ProviderInput servicesProviderInput)
        {
            return await mediator.Send(new CreateProviderCommand(servicesProviderInput));
        }
        public async Task<ProviderOutput> UpdateServicesProvider([Service] IMediator mediator, Guid servicesProviderId, ProviderInput servicesProviderInput)
        {
            return await mediator.Send(new UpdateProviderCommand(servicesProviderId, servicesProviderInput));
        }
        public async Task DeleteServicesProvider([Service] IMediator mediator, Guid servicesProviderId)
        {
            await mediator.Send(new DeleteProviderCommand(servicesProviderId));
        }
    }
}
