using HireServices.Features.ServiceProviders.Domain.ValueObjects;
using HireServices.Features.ServiceProviders.GraphQL.Inputs;

namespace HireServices.Features.ServiceProviders.Extensions
{
    public static class CategoryExtensions
    {
        public static Category ToCategory(this CategoryInput categoryInput) =>
            new Category(categoryInput.Name, categoryInput.Description);
    }
}
