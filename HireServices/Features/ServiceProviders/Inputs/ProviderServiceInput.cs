using HireServices.Features.ServiceProviders.Domain.ValueObjects;

namespace HireServices.Features.ServiceProviders.Inputs
{
    public class ProviderServiceInput
    {
        public Guid? Id { get; set; }
        [GraphQLNonNullType]
        public string Name { get; set; }
        public string Description { get; set; }

        [GraphQLNonNullType]
        public decimal Price { get; set; }

        [GraphQLNonNullType]
        public required string Currency { get; set; }

        [GraphQLNonNullType]
        public string Duration { get; set; }

        [GraphQLNonNullType]
        public CategoryInput CategoryInput { get; set; }
    }
}
