using HireServices.Domain.Common;
using HireServices.Domain.ValueObjects;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace HireServices.Features.ServiceProviders.Domain.AggregateRoots
{
    public class ServicesProvider: BaseEntity
    {
        public ContactInfo ContactInfo { get; set; }
        public Address Address { get; set; }

        public JsonDocument Services { get; set; }

        public class ServicesProviderBuilder
        {
            private ServicesProvider _serviceProvider;
            public ServicesProviderBuilder()
            {
                _serviceProvider = new ServicesProvider();
            }
            public ServicesProviderBuilder WithContactInfo(ContactInfo contactInfo)
            {
                _serviceProvider.ContactInfo = contactInfo;
                return this;
            }
            public ServicesProviderBuilder WithAddress(Address address)
            {
                _serviceProvider.Address = address;
                return this;
            }
            public ServicesProviderBuilder WithServices(List<Service> services)
            {
                var options = new JsonSerializerOptions
                {
                    TypeInfoResolver = new DefaultJsonTypeInfoResolver()
                };
                _serviceProvider.Services = JsonDocument.Parse(JsonSerializer.Serialize(services, options));
                return this;
            }
            public ServicesProvider Build()
            {
                return _serviceProvider;
            }
        }
    }
}
