using MediatR;

namespace HireServices.Features.ServiceProviders.Commands.DeleteServicesProvider
{
    public record DeleteServicesProviderCommand(Guid servicesProviderId) : IRequest<bool>
    {
    }
}
