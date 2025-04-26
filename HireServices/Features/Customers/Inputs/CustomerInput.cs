using HireServices.Domain.Inputs;
using HotChocolate;
using System.ComponentModel.DataAnnotations;

namespace HireServices.Features.Customers.Inputs
{
    public class CustomerInput
    {
        [GraphQLNonNullType]
        public ContactInfoInput ContactInfoInput { get; set; }
        public List<AddressInput>? AddressesInput { get; set; }
    }
}
