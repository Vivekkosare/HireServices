using HireServices.Domain.Common;
using HireServices.Domain.ValueObjects;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace HireServices.Features.Customers.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public ContactInfo ContactInfo { get; set; }
        public JsonDocument Addresses { get; set; }
        public class CustomerBuilder
        {
            private Customer _customer;
            public CustomerBuilder()
            {
                _customer = new Customer();
            }
            public CustomerBuilder WithContactInfo(ContactInfo contactInfo)
            {
                _customer.ContactInfo = contactInfo;
                return this;
            }
            public CustomerBuilder WithAddresses(List<Address> addresses)
            {
                var options = new JsonSerializerOptions
                {
                    TypeInfoResolver = new DefaultJsonTypeInfoResolver()
                };
                _customer.Addresses = JsonDocument.Parse(JsonSerializer.Serialize(addresses, options));
                return this;
            }
            public Customer Build()
            {
                return _customer;
            }
        }
    }
}
