using HireServices.Domain.DTOs;
using HireServices.Domain.Extensions;
using HireServices.Domain.ValueObjects;
using System.Text.Json;

namespace HireServices.Features.ServiceProviders.DTOs
{
    public record ServicesProviderOutput
    {
        public ContactInfoOutput ContactInfoOutput { get; set; }
        public AddressOutput? AddressOutput { get; set; }
        public List<ServiceOutput>? ServicesOutput { get; set; }
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        //public ServicesProviderOutput(ContactInfoOutput contactInfoOutput,
        //    AddressOutput addressOutput,
        //    Guid id, DateTime createdAt, DateTime updatedAt)
        //{
        //    ContactInfoOutput = contactInfoOutput;
        //    AddressOutput = addressOutput;
        //    Id = id;
        //    CreatedAt = createdAt;
        //    UpdatedAt = updatedAt;
        //}
        public class ServicesProviderOutputBuilder
        {
            ServicesProviderOutput _serviceProviderOutput;
            public ServicesProviderOutputBuilder()
            {
                _serviceProviderOutput = new ServicesProviderOutput();
            }
            public ServicesProviderOutputBuilder WithContactInfoOutput(ContactInfo contactInfo)
            {
                _serviceProviderOutput.ContactInfoOutput = contactInfo.ToContactInfoOutput();
                return this;
            }
            public ServicesProviderOutputBuilder WithAddressOutput(JsonDocument address)
            {
                _serviceProviderOutput.AddressOutput = address is not null? JsonSerializer.Deserialize<AddressOutput>(address.RootElement.GetRawText()) : null;
                return this;
            }
            public ServicesProviderOutputBuilder WithServicesOutput(JsonDocument servicesDocument)
            {
                _serviceProviderOutput.ServicesOutput = servicesDocument is not null ? JsonSerializer.Deserialize<List<ServiceOutput>>(servicesDocument.RootElement.GetRawText()) : null;
                return this;
            }
            public ServicesProviderOutputBuilder WithId(Guid id)
            {
                _serviceProviderOutput.Id = id;
                return this;
            }
            public ServicesProviderOutputBuilder WithCreatedAt(DateTime createdAt)
            {
                _serviceProviderOutput.CreatedAt = createdAt;
                return this;
            }
            public ServicesProviderOutputBuilder WithUpdatedAt(DateTime updatedAt)
            {
                _serviceProviderOutput.UpdatedAt = updatedAt;
                return this;
            }
            public ServicesProviderOutput Build()
            {
                return _serviceProviderOutput;
            }

        }
    }
}
