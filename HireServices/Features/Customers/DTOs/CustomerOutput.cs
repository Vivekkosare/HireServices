using HireServices.Common.DTOs;
using System.Text.Json;

namespace HireServices.Features.Customers.DTOs
{
    public record CustomerOutput
    {
        public ContactInfoOutput ContactInfoOutput { get; init; }
        public List<AddressOutput>? AddressesOutput { get; init; }
        public Guid Id { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }
        public CustomerOutput(ContactInfoOutput contactInfoOutput, JsonDocument addressesJson, Guid id, DateTime createdAt, DateTime updatedAt)
        {
            ContactInfoOutput = contactInfoOutput;
            AddressesOutput = JsonSerializer.Deserialize<List<AddressOutput>>(addressesJson.RootElement.GetRawText());
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
