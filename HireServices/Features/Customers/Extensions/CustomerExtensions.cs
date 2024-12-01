using HireServices.Domain.Extensions;
using HireServices.Domain.Inputs;
using HireServices.Domain.ValueObjects;
using HireServices.Features.Customers.Domain.Entities;
using HireServices.Features.Customers.GraphQL.Inputs;

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
    }
}
