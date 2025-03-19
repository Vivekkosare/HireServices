using HireServices.Domain.Common;
using HireServices.Features.ServiceProviders.GraphQL.Inputs;
using MediatR;

namespace HireServices.Features.ServiceProviders.Commands.CreateServicesProvider
{
    public record CreateProviderCommand(ProviderInput Input) : IRequest<ResultResponse<DTOs.ProviderOutput>>
    {
    }
}
