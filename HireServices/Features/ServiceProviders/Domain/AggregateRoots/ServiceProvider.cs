using HireServices.Domain.Common;
using HireServices.Domain.ValueObjects;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace HireServices.Features.ServiceProviders.Domain.AggregateRoots
{
    public class ServiceProvider: BaseEntity
    {
        public ContactInfo ContactInfo { get; set; }
        public Address Address { get; set; }

        public JsonDocument Services { get; set; }

        public class ServiceProviderBuilder
        {
            private ServiceProvider _serviceProvider;
            public ServiceProviderBuilder()
            {
                _serviceProvider = new ServiceProvider();
            }
            public ServiceProviderBuilder WithContactInfo(ContactInfo contactInfo)
            {
                _serviceProvider.ContactInfo = contactInfo;
                return this;
            }
            public ServiceProviderBuilder WithAddress(Address address)
            {
                _serviceProvider.Address = address;
                return this;
            }
            public ServiceProviderBuilder WithServices(List<Service> services)
            {
                var options = new JsonSerializerOptions
                {
                    TypeInfoResolver = new DefaultJsonTypeInfoResolver()
                };
                _serviceProvider.Services = JsonDocument.Parse(JsonSerializer.Serialize(services, options));
                return this;
            }
            public ServiceProvider Build()
            {
                return _serviceProvider;
            }
        }
    }
}
