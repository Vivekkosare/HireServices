using HotChocolate;
using System.ComponentModel.DataAnnotations;

namespace HireServices.Domain.Inputs
{
    public class ContactInfoInput
    {
        [GraphQLNonNullType]
        public string FirstName { get; set; }

        [GraphQLNonNullType]
        public string LastName { get; set; }

        [GraphQLNonNullType]
        [EmailAddress]
        public string Email { get; set; }

        [GraphQLNonNullType]
        public string PhoneNumber { get; set; }

        [GraphQLType(typeof(NonNullType<DateTimeType>))]
        public DateTime DateOfBirth { get; set; }
    }
}
