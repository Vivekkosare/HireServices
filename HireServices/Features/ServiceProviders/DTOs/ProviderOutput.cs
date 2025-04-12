using HireServices.Domain.DTOs;

namespace HireServices.Features.ServiceProviders.DTOs
{
    public record ProviderOutput
    {
        public ContactInfoOutput ContactInfoOutput { get; set; }
        public AddressOutput? AddressOutput { get; set; }
        public List<string>? ServiceTags { get; set; }
        public List<string>? ServiceCategories { get; set; }
        public List<ProviderServiceOutput>? HighlightedServices { get; set; }
        public decimal AverageRating { get; set; }
        public int CustomersServed { get; set; }
        public List<ProviderReviewOutput>? LatestReviews { get; set; }
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
    }
}
