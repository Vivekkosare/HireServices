namespace HireServices.Domain.ValueObjects
{
    public class Address
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }

        public class AddressBuilder
        {
            private readonly Address _address;
            public AddressBuilder()
            {
                _address = new Address();
                _address.Id = Guid.NewGuid();
            }
            public AddressBuilder WithStreet(string street)
            {
                _address.Street = street;
                return this;
            }
            public AddressBuilder WithCity(string city)
            {
                _address.City = city;
                return this;
            }
            public AddressBuilder WithState(string state)
            {
                _address.State = state;
                return this;
            }
            public AddressBuilder WithZipCode(string zipCode)
            {
                _address.ZipCode = zipCode;
                return this;
            }
            public AddressBuilder WithCountry(string country)
            {
                _address.Country = country;
                return this;
            }
            public Address Build()
            {
                return _address;
            }

        }
    }
}
