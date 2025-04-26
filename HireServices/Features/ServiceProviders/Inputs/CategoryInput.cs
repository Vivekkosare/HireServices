namespace HireServices.Features.ServiceProviders.Inputs
{
    public class CategoryInput
    {
        [GraphQLNonNullType]
        public string Name { get; set; }

        [GraphQLNonNullType]
        public string Description { get; set; }
    }
}
