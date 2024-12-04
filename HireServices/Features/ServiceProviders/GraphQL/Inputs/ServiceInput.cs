using HireServices.Features.ServiceProviders.Domain.ValueObjects;

namespace HireServices.Features.ServiceProviders.GraphQL.Inputs
{
    public class ServiceInput
    {
        [GraphQLNonNullType]
        public string Name { get; set; }
        public string Description { get; set; }
        
        [GraphQLNonNullType]
        public decimal Price { get; set; }
        
        [GraphQLNonNullType]
        public TimeSpan Duration { get; set; }
        
        [GraphQLNonNullType]
        public Category Category { get; set; }
    }
}
