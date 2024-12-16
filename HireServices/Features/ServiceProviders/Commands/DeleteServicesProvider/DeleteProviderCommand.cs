using MediatR;

namespace HireServices.Features.ServiceProviders.Commands.DeleteServicesProvider
{
    public record DeleteProviderCommand(Guid servicesProviderId) : IRequest<bool>
    {
    }
}
