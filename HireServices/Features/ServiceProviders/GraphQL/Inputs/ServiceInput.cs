using HireServices.Features.ServiceProviders.Domain.ValueObjects;

namespace HireServices.Features.ServiceProviders.GraphQL.Inputs
{
    public class ServiceInput
    {
        public Guid? Id { get; set; }
        [GraphQLNonNullType]
        public string Name { get; set; }
        public string Description { get; set; }

        [GraphQLNonNullType]
        public decimal Price { get; set; }

        [GraphQLNonNullType]
        public string Duration { get; set; }

        [GraphQLNonNullType]
        public CategoryInput CategoryInput { get; set; }
    }
}
