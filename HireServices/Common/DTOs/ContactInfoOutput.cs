using System.ComponentModel.DataAnnotations;

namespace HireServices.Common.DTOs
{
    public record ContactInfoOutput
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public string PhoneNumber { get; init; }
        public DateTime DateOfBirth { get; init; }

        public ContactInfoOutput(string firstName, string lastName, string email, string phoneNumber, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
        }


    }
}
