using HireServices.Common;
using System.Text.Json;

namespace HireServices.Features.ServiceProviders.Domain.Entities
{
    public class ProviderService : BaseEntity
    {
        public Guid ProviderId { get; set; }
        public Provider Provider { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public TimeSpan Duration { get; set; }
        public JsonDocument Category { get; set; }
    }
}
