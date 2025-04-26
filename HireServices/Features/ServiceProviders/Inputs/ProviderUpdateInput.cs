using HireServices.Common.Inputs;

namespace HireServices.Features.ServiceProviders.Inputs
{
    public class ProviderUpdateInput
    {
        [GraphQLNonNullType]
        public ContactInfoInput ContactInfoInput { get; set; }

        [GraphQLNonNullType]
        public AddressInput AddressInput { get; set; }
    }
}
