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
    }
}
