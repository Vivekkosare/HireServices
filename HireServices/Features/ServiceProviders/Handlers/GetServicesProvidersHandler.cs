using HireServices.Features.ServiceProviders.DTOs;
using HireServices.Features.ServiceProviders.Queries;
using MediatR;

namespace HireServices.Features.ServiceProviders.Handlers
{
    public class GetServicesProvidersHandler : IRequestHandler<GetServicesProvidersQuery, List<ServicesProviderOutput>>
    {
        public Task<List<ServicesProviderOutput>> Handle(GetServicesProvidersQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
