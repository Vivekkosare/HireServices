using HireServices.Domain.Common;
using HireServices.Domain.ValueObjects;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace HireServices.Features.ServiceProviders.Domain.Entities
{
    public class Provider : BaseEntity
    {
        public ContactInfo ContactInfo { get; set; }
        public JsonDocument Address { get; set; }
        public List<string> ServiceTags { get; set; }
        public List<string> ServiceCategories { get; set; }
        public List<ProviderService> ProviderServices { get; set; } = new List<ProviderService>();
        public JsonDocument HighlightedServices { get; set; }
        public decimal? AverageRating { get; set; }
        public int CustomersServed { get; set; }
        public JsonDocument? LatestReviews { get; set; }
    }
}
