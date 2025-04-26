using HireServices.Domain.Extensions;
using HireServices.Domain.Inputs;
using HireServices.Domain.ValueObjects;
using HireServices.Features.Customers.Domain.Entities;
using HireServices.Features.Customers.DTOs;
using HireServices.Features.Customers.Inputs;
using System.Text.Json;
using static HireServices.Features.Customers.DTOs.CustomerOutput;

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

        

        public static CustomerOutput ToCustomerOutput(this Customer customer)
        {
            return new CustomerOutput(customer.ContactInfo.ToContactInfoOutput(), 
                customer.Addresses, 
                customer.Id, 
                customer.CreatedAt, 
                customer.UpdatedAt);
        }
    }
}
