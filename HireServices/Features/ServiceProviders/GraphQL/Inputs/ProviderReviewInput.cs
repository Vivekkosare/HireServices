using HireServices.Domain.Common;

namespace HireServices.Features.ServiceProviders.GraphQL.Inputs
{
    public class ProviderReviewInput
    {
        public Guid ProviderId { get; set; }
        public Guid CustomerId { get; set; }
        public string Review { get; set; }
        public decimal Rating { get; set; }
        public bool Flagged { get; set; }
    }
}
