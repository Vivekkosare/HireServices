using HireServices.Features.ServiceProviders.DTOs;
using System.Text.Json;

namespace HireServices.Features.ServiceProviders.Domain.Builders
{
    public record ProviderServiceOutputBuilder
    {
        ProviderServiceOutput _service;
        public ProviderServiceOutputBuilder()
        {
            _service = new ProviderServiceOutput();
        }
        public ProviderServiceOutputBuilder WithId(Guid id)
        {
            _service.Id = id;
            return this;
        }
        public ProviderServiceOutputBuilder WithProviderId(Guid providerId)
        {
            _service.ProviderId = providerId;
            return this;
        }
        public ProviderServiceOutputBuilder WithName(string name)
        {
            _service.Name = name;
            return this;
        }
        public ProviderServiceOutputBuilder WithDescription(string description)
        {
            _service.Description = description;
            return this;
        }
        public ProviderServiceOutputBuilder WithPrice(decimal price)
        {
            _service.Price = price;
            return this;
        }
        public ProviderServiceOutputBuilder WithDuration(TimeSpan duration)
        {
            _service.Duration = duration;
            return this;
        }
        public ProviderServiceOutputBuilder WithCategory(JsonDocument category)
        {
            _service.Category = category is not null ? JsonSerializer.Deserialize<CategoryOutput>(category.RootElement.GetRawText()) : default;
            return this;
        }
        public ProviderServiceOutputBuilder WithCreatedAt(DateTime createdAt)
        {
            _service.CreatedAt = createdAt;
            return this;
        }
        public ProviderServiceOutputBuilder WithUpdatedAt(DateTime updatedAt)
        {
            _service.UpdatedAt = updatedAt;
            return this;
        }
        public ProviderServiceOutput Build()
        {
            return _service;
        }
    }
}
