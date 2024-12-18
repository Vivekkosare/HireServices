namespace HireServices.Features.ServiceProviders.Domain.AggregateRoots
{
    public class LatestProviderReviews
    {
        public int MaxAllowedReviews { get; set; }
        public List<ProviderReview> ProviderReviews { get; set; }
    }
}
