using HireServices.Common.DTOs;
using HireServices.Common.Inputs;
using HireServices.Common.ValueObjects;

namespace HireServices.Common.Extensions
{
    public static class ContactInfoExtensions
    {
        public static ContactInfo ToContactInfo(this ContactInfoInput contactInfoInput)
        {
            return new ContactInfo.ContactInfoBuilder()
                .WithFirstName(contactInfoInput.FirstName)
                .WithLastName(contactInfoInput.LastName)
                .WithEmail(contactInfoInput.Email)
                .WithPhoneNumber(contactInfoInput.PhoneNumber)
                .WithDateOfBirth(contactInfoInput.DateOfBirth)
                .Build();
        }

        public static ContactInfoOutput ToContactInfoOutput(this ContactInfo contactInfo)
        {
            return new ContactInfoOutput(contactInfo.FirstName,
                contactInfo.LastName,
                contactInfo.Email,
                contactInfo.PhoneNumber,
                contactInfo.DateOfBirth);
        }
    }
}
