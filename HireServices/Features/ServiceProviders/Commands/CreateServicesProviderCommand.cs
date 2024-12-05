using HireServices.Features.ServiceProviders.GraphQL.Inputs;
using MediatR;

namespace HireServices.Features.ServiceProviders.Commands
{
    public record CreateServicesProviderCommand(ServicesProviderInput Input) : IRequest<DTOs.ServicesProviderOutput>
    {
    }
}
