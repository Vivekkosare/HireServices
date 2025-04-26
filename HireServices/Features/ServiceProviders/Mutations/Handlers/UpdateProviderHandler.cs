using HireServices.Features.ServiceProviders.DTOs;
using HireServices.Features.ServiceProviders.Extensions;
using HireServices.Features.ServiceProviders.Services;
using MediatR;
using System.Text.Json.Serialization.Metadata;
using System.Text.Json;
using HireServices.Features.ServiceProviders.Inputs;
using HireServices.Common.Extensions;

namespace HireServices.Features.ServiceProviders.Mutations.Handlers
{
    public record UpdateProviderCommand(Guid ProviderId, ProviderUpdateInput UpdateInput) : IRequest<ProviderOutput>;
    public class UpdateProviderHandler : IRequestHandler<UpdateProviderCommand, ProviderOutput>
    {
        private readonly IProviderServicesService _providerService;

        public UpdateProviderHandler(IProviderServicesService providerService)
        {
            _providerService = providerService;
        }
        public async Task<ProviderOutput> Handle(UpdateProviderCommand request, CancellationToken cancellationToken)
        {
            var provider = await _providerService.GetProviderAsync(request.ProviderId);
            if (provider == null)
            {
                throw new Exception("Services provider not found to update");
            }
            provider.ContactInfo = request.UpdateInput.ContactInfoInput.ToContactInfo();

            var options = new JsonSerializerOptions
            {
                TypeInfoResolver = new DefaultJsonTypeInfoResolver()
            };
            provider.Address = JsonDocument.Parse(JsonSerializer.Serialize(request.UpdateInput.AddressInput.ToAddress(), options));
            provider.UpdatedAt = DateTime.UtcNow;

            var providerUpdated = await _providerService.UpdateProviderAsync(request.ProviderId, provider);
            if (providerUpdated == null)
            {
                throw new Exception("Error updating services provider");
            }
            return providerUpdated.ToProviderOutput();
        }
    }
}
