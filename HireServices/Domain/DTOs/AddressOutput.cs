using HireServices.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace HireServices.Domain.DTOs
{
    public record AddressOutput
    {
        public Guid Id { get; init; }
        public string Street { get; init; }
        public string City { get; init; }
        public string ZipCode { get; init; }
        public string State { get; init; }
        public string Country { get; init; }
        public AddressOutput(string street, string city, string zipCode, string state, string country, Guid id)
        {
            Id = id;
            Street = street;
            City = city;
            ZipCode = zipCode;
            State = state;
            Country = country;
        }
    }

}
