using HireServices.Features.ServiceProviders.Domain.ValueObjects;
using System.Text.Json;

namespace HireServices.Features.ServiceProviders.DTOs
{
    public record ProviderServiceOutput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
        public CategoryOutput Category { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

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
}
