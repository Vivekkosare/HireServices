using HireServices.Domain.Inputs;

namespace HireServices.Features.ServiceProviders.GraphQL.Inputs
{
    public class ProviderInput
    {
        [GraphQLNonNullType]
        public ContactInfoInput ContactInfoInput { get; set; }
        
        [GraphQLNonNullType]
        public AddressInput AddressInput { get; set; }
        
        [GraphQLNonNullType]
        public List<ServiceInput> ServicesInput { get; set; }
    }
}
