namespace HireServices.Domain.ValueObjects
{
    public class ContactInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        public class ContactInfoBuilder
        {
            private readonly ContactInfo _contactInfo;

            public ContactInfoBuilder()
            {
                _contactInfo = new ContactInfo();
            }

            public ContactInfoBuilder WithFirstName(string firstName)
            {
                _contactInfo.FirstName = firstName;
                return this;
            }

            public ContactInfoBuilder WithLastName(string lastName)
            {
                _contactInfo.LastName = lastName;
                return this;
            }

            public ContactInfoBuilder WithEmail(string email)
            {
                _contactInfo.Email = email;
                return this;
            }

            public ContactInfoBuilder WithPhoneNumber(string phoneNumber)
            {
                _contactInfo.PhoneNumber = phoneNumber;
                return this;
            }

            public ContactInfoBuilder WithDateOfBirth(DateTime dateOfBirth)
            {
                _contactInfo.DateOfBirth = dateOfBirth;
                return this;
            }

            public ContactInfo Build()
            {
                return _contactInfo;
            }
        }
    }
}
