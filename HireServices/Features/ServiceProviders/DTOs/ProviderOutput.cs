using HireServices.Domain.DTOs;
using HireServices.Domain.Extensions;
using HireServices.Domain.ValueObjects;
using System.Text.Json;

namespace HireServices.Features.ServiceProviders.DTOs
{
    public record ProviderOutput
    {
        public ContactInfoOutput ContactInfoOutput { get; set; }
        public AddressOutput? AddressOutput { get; set; }
        public List<string>? ServiceTags { get; set; }
        public List<string>? ServiceCategories { get; set; }
        public List<ProviderServiceOutput>? HighlightedServices { get; set; }
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public class ProviderOutputBuilder
        {
            ProviderOutput _serviceProviderOutput;
            public ProviderOutputBuilder()
            {
                _serviceProviderOutput = new ProviderOutput();
            }
            public ProviderOutputBuilder WithContactInfoOutput(ContactInfo contactInfo)
            {
                _serviceProviderOutput.ContactInfoOutput = contactInfo.ToContactInfoOutput();
                return this;
            }
            public ProviderOutputBuilder WithAddressOutput(JsonDocument address)
            {
                _serviceProviderOutput.AddressOutput = address is not null? JsonSerializer.Deserialize<AddressOutput>(address.RootElement.GetRawText()) : null;
                return this;
            }
            public ProviderOutputBuilder WithServiceTags(List<string> serviceTags)
            {
                _serviceProviderOutput.ServiceTags = serviceTags;
                return this;
            }
            public ProviderOutputBuilder WithServiceCategories(List<string> serviceCategories)
            {
                _serviceProviderOutput.ServiceCategories = serviceCategories;
                return this;
            }
            public ProviderOutputBuilder WithId(Guid id)
            {
                _serviceProviderOutput.Id = id;
                return this;
            }
            public ProviderOutputBuilder WithCreatedAt(DateTime createdAt)
            {
                _serviceProviderOutput.CreatedAt = createdAt;
                return this;
            }
            public ProviderOutputBuilder WithUpdatedAt(DateTime updatedAt)
            {
                _serviceProviderOutput.UpdatedAt = updatedAt;
                return this;
            }
            public ProviderOutputBuilder WithHightlightedServices(JsonDocument highlightedServices)
            {
                _serviceProviderOutput.HighlightedServices = highlightedServices;
                return this;
            }
            public ProviderOutput Build()
            {
                return _serviceProviderOutput;
            }

        }
    }
}
