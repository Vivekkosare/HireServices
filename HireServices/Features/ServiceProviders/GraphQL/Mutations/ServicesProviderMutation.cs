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
    public class ServicesProviderMutationExtension: ServicesProviderMutation
    {
    }
    public class Mutation
    {
        public string Echo(string message) => message;
    }
    public class ServicesProviderMutation
    {
        public async Task<ServicesProviderOutput> CreateServicesProvider([Service] IMediator mediator, ServicesProviderInput servicesProviderInput)
        {
            return await mediator.Send(new CreateServicesProviderCommand(servicesProviderInput));
        }
        public async Task<ServicesProviderOutput> UpdateServicesProvider([Service] IMediator mediator, Guid servicesProviderId, ServicesProviderInput servicesProviderInput)
        {
            return await mediator.Send(new UpdateServicesProviderCommand(servicesProviderId, servicesProviderInput));
        }
        public async Task DeleteServicesProvider([Service] IMediator mediator, Guid servicesProviderId)
        {
            await mediator.Send(new DeleteServicesProviderCommand(servicesProviderId));
        }
    }
}
