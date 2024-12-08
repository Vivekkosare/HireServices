using HireServices.Features.ServiceProviders.GraphQL.Inputs;
using MediatR;

namespace HireServices.Features.ServiceProviders.Commands.CreateServicesProvider
{
    public record CreateServicesProviderCommand(ServicesProviderInput Input) : IRequest<DTOs.ServicesProviderOutput>
    {
    }
}
