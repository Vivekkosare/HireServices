using HireServices.Domain.DTOs;

namespace HireServices.Features.ServiceProviders.DTOs
{
    public record ServicesProviderOutput
    {
        public ContactInfoOutput ContactInfoOutput { get; init; }
        public AddressOutput? AddressOutput { get; init; }
        public Guid Id { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }
        public ServicesProviderOutput(ContactInfoOutput contactInfoOutput,
            AddressOutput addressOutput,
            Guid id, DateTime createdAt, DateTime updatedAt)
        {
            ContactInfoOutput = contactInfoOutput;
            AddressOutput = addressOutput;
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
