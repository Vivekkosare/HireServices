using HireServices.Common.Inputs;

namespace HireServices.Features.ServiceProviders.Inputs
{
    public class ProviderInput
    {
        [GraphQLNonNullType]
        public ContactInfoInput ContactInfoInput { get; set; }

        [GraphQLNonNullType]
        public AddressInput AddressInput { get; set; }

        [GraphQLNonNullType]
        public List<ProviderServiceInput> ServicesInput { get; set; }

        //public List<ProviderReviewInput>? ProviderReviewsInput { get; set; }
    }
}
