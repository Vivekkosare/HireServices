using HireServices.Features.ServiceProviders.Domain.ValueObjects;
using System.Text.Json;

namespace HireServices.Features.ServiceProviders.DTOs
{
    public record ProviderServiceOutput
    {
        public Guid Id { get; set; }
        public Guid ProviderId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
        public CategoryOutput Category { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }        
    }
}
