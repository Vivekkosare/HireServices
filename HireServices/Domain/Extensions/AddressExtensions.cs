using HireServices.Domain.DTOs;
using HireServices.Domain.Inputs;
using HireServices.Domain.ValueObjects;

namespace HireServices.Domain.Extensions
{
    public static class AddressExtensions
    {
        public static Address ToAddress(this AddressInput addressInput)
        {
            return new Address.AddressBuilder()
                .WithStreet(addressInput.Street)
                .WithCity(addressInput.City)
                .WithZipCode(addressInput.ZipCode)
                .WithState(addressInput.State)
                .WithCountry(addressInput.Country)
                .Build();
        }

        public static List<Address> ToAddresses(this List<AddressInput> addressInputs)
        {
            return addressInputs.Select(addressInput => addressInput.ToAddress()).ToList();
        }

        public static AddressOutput ToAddressOutput(this Address address)
        {
            return new AddressOutput(address.Street, 
                address.City, 
                address.ZipCode, 
                address.State, 
                address.Country, 
                address.Id);
        }
    }
}
