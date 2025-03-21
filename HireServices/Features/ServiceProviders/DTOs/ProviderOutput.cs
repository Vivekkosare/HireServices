﻿using HireServices.Domain.DTOs;
using HireServices.Domain.Extensions;
using HireServices.Domain.ValueObjects;
using HireServices.Features.ServiceProviders.Domain.AggregateRoots;
using System.Text.Json;

namespace HireServices.Features.ServiceProviders.DTOs
{
    //[GraphQLType(typeof(ObjectType<ProviderOutput>))]
    public record ProviderOutput
    {
        public ContactInfoOutput ContactInfoOutput { get; set; }
        public AddressOutput? AddressOutput { get; set; }
        public List<string>? ServiceTags { get; set; }
        public List<string>? ServiceCategories { get; set; }
        public List<ProviderServiceOutput>? HighlightedServices { get; set; }
        public decimal AverageRating { get; set; }
        public int CustomersServed { get; set; }
        public List<ProviderReviewOutput>? LatestReviews { get; set; }
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
                _serviceProviderOutput.AddressOutput = address is not null ? JsonSerializer.Deserialize<AddressOutput>(address.RootElement.GetRawText()) : default;
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
            public ProviderOutputBuilder WithHighlightedServices(JsonDocument highlightedServices)
            {
                if (highlightedServices is not null)
                {
                    List<ProviderService> providerServices = JsonSerializer.Deserialize<List<ProviderService>>(highlightedServices.RootElement.GetRawText());
                    _serviceProviderOutput.HighlightedServices = providerServices.Select(service =>
                        new ProviderServiceOutput.ProviderServiceOutputBuilder()
                            .WithId(service.Id ?? Guid.Empty) // Fix for CS1503
                            .WithProviderId(service.ProviderId)
                            .WithName(service.Name)
                            .WithDescription(service.Description)
                            .WithPrice(service.Price)
                            .WithDuration(service.Duration)
                            .WithCategory(JsonDocument.Parse(JsonSerializer.Serialize(service.Category)))
                            .WithCreatedAt(service.CreatedAt)
                            .WithUpdatedAt(service.UpdatedAt)
                            .Build()
                    ).ToList();
                }
                else { _serviceProviderOutput.HighlightedServices = default; }
                return this;
            }
            public ProviderOutputBuilder WithAverageRating(decimal averageRating)
            {
                _serviceProviderOutput.AverageRating = averageRating;
                return this;
            }
            public ProviderOutputBuilder WithLatestReviews(JsonDocument latestReviews)
            {
                _serviceProviderOutput.LatestReviews = latestReviews is not null ?
                    JsonSerializer.Deserialize<List<ProviderReviewOutput>>(latestReviews.RootElement.GetRawText()) : default;
                return this;
            }
            public ProviderOutputBuilder WithCustomersServed(int customersServed)
            {
                _serviceProviderOutput.CustomersServed = customersServed;
                return this;
            }
            public ProviderOutput Build()
            {
                return _serviceProviderOutput;
            }

        }
    }
}
