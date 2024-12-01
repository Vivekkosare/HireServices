using HireServices.Domain.Extensions;
using HireServices.Domain.Inputs;
using HireServices.Domain.ValueObjects;
using HireServices.Features.Customers.Domain.Entities;
using HireServices.Features.Customers.GraphQL.Inputs;
using System.Text.Json;

namespace HireServices.Features.Customers.Extensions
{
    public static class CustomerExtensions
    {
        public static Customer ToCustomer(this CustomerInput customerInput)
        {
            var contactInfo = customerInput.ContactInfoInput.ToContactInfo();
            var addresses = customerInput.AddressesInput?.ToAddresses() ?? new List<Address>();

            return new Customer.CustomerBuilder()
                .WithContactInfo(contactInfo)
                .WithAddresses(addresses)
                .Build();
        }

        public static Customer MapCustomerToUpdate(this Customer customerToBeUpdated, Customer updatingCustomer)
        {
            ContactInfo updatingContactInfo = updatingCustomer.ContactInfo;
            customerToBeUpdated.ContactInfo.FirstName = customerToBeUpdated.ContactInfo.FirstName != updatingContactInfo.FirstName &&
                !string.IsNullOrWhiteSpace(updatingContactInfo.FirstName) ? updatingContactInfo.FirstName : customerToBeUpdated.ContactInfo.FirstName;

            customerToBeUpdated.ContactInfo.LastName = customerToBeUpdated.ContactInfo.LastName != updatingContactInfo.LastName &&
                !string.IsNullOrWhiteSpace(updatingContactInfo.LastName) ? updatingContactInfo.LastName : customerToBeUpdated.ContactInfo.LastName;

            customerToBeUpdated.ContactInfo.Email = customerToBeUpdated.ContactInfo.Email != updatingContactInfo.Email &&
                !string.IsNullOrWhiteSpace(updatingContactInfo.Email) ? updatingContactInfo.Email : customerToBeUpdated.ContactInfo.Email;

            customerToBeUpdated.ContactInfo.PhoneNumber = customerToBeUpdated.ContactInfo.PhoneNumber != updatingContactInfo.PhoneNumber &&
                !string.IsNullOrWhiteSpace(updatingContactInfo.PhoneNumber) ? updatingContactInfo.PhoneNumber : customerToBeUpdated.ContactInfo.PhoneNumber;

            customerToBeUpdated.ContactInfo.DateOfBirth = customerToBeUpdated.ContactInfo.DateOfBirth != updatingContactInfo.DateOfBirth &&
                !string.IsNullOrWhiteSpace(updatingContactInfo.DateOfBirth.ToString()) ? updatingContactInfo.DateOfBirth : customerToBeUpdated.ContactInfo.DateOfBirth;

            List<Address> addressesToBeUpdated = new();
            if (updatingCustomer.Addresses != null)
            {
                addressesToBeUpdated = JsonSerializer.Deserialize<List<Address>>(customerToBeUpdated.Addresses?.RootElement.GetRawText() ?? "[]");
                List<Address> updatingAddresses = JsonSerializer.Deserialize<List<Address>>(updatingCustomer.Addresses?.RootElement.GetRawText() ?? "[]");
                //if (updatingAddresses != null)
                //{ 
                    foreach (var updatingAddress in updatingAddresses)
                    {
                        var address = addressesToBeUpdated?.FirstOrDefault(a => a.Id == updatingAddress.Id);
                        if (address != null)
                        {
                            address.Street = address.Street != updatingAddress.Street &&
                                !string.IsNullOrWhiteSpace(updatingAddress.Street) ? updatingAddress.Street : address.Street;
                            address.City = address.City != updatingAddress.City &&
                                !string.IsNullOrWhiteSpace(updatingAddress.City) ? updatingAddress.City : address.City;
                            address.State = address.State != updatingAddress.State &&
                                !string.IsNullOrWhiteSpace(updatingAddress.State) ? updatingAddress.State : address.State;
                            address.ZipCode = address.ZipCode != updatingAddress.ZipCode &&
                                !string.IsNullOrWhiteSpace(updatingAddress.ZipCode) ? updatingAddress.ZipCode : address.ZipCode;
                        }
                        else
                        {
                            addressesToBeUpdated?.Add(updatingAddress);
                        }
                    }
                //}
            }
            if (addressesToBeUpdated?.Count > 0)
            {
                customerToBeUpdated.Addresses = JsonDocument.Parse(JsonSerializer.Serialize(addressesToBeUpdated));
            }

            return customerToBeUpdated;
        }
    }
}
