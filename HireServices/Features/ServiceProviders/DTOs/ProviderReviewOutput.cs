namespace HireServices.Features.ServiceProviders.DTOs
{
    public record ProviderReviewOutput
    {
        public Guid ProviderId { get; set; }
        public Guid CustomerId { get; set; }
        public string Review { get; set; }
        public decimal Rating { get; set; }
        public bool Flagged { get; set; }
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
