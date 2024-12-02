using HireServices.Domain.DTOs;
using HireServices.Domain.Inputs;
using HireServices.Domain.ValueObjects;

namespace HireServices.Domain.Extensions
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
