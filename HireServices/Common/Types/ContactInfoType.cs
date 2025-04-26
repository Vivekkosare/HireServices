using HireServices.Common.ValueObjects;
using HotChocolate.Types;
using System.ComponentModel.DataAnnotations;

namespace HireServices.Common.Types
{
    public class ContactInfoType : ObjectType<ContactInfo>
    {
        protected override void Configure(IObjectTypeDescriptor<ContactInfo> descriptor)
        {
            descriptor.Field(c => c.FirstName)
                .Type<NonNullType<StringType>>()
                .Description("The first name of the contact.");

            descriptor.Field(c => c.LastName)
                .Type<NonNullType<StringType>>()
                .Description("The last name of the contact.");

            descriptor.Field(c => c.Email)
                .Type<NonNullType<StringType>>()
                .Description("The email address of the contact.");

            descriptor.Field(c => c.PhoneNumber)
                .Type<NonNullType<StringType>>()
                .Description("The phone number of the contact.");

            descriptor.Field(c => c.DateOfBirth)
                .Type<NonNullType<DateType>>()
                .Description("The date of birth of the contact.");
        }
    }
}
