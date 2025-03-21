﻿using HireServices.Domain.Common;
using HireServices.Domain.ValueObjects;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace HireServices.Features.ServiceProviders.Domain.AggregateRoots
{
    public class Provider: BaseEntity
    {
        public ContactInfo ContactInfo { get; set; }
        public JsonDocument Address { get; set; }
        public List<string> ServiceTags { get; set; }
        public List<string> ServiceCategories { get; set; }
        public List<ProviderService> ProviderServices { get; set; }
        public JsonDocument HighlightedServices { get; set; }
        public decimal? AverageRating { get; set; }
        public int CustomersServed { get; set; }
        public JsonDocument? LatestReviews { get; set; }


        public class ProviderBuilder
        {
            private Provider _serviceProvider;
            private JsonSerializerOptions _options;
            public ProviderBuilder()
            {
                _serviceProvider = new Provider();
                _options = new JsonSerializerOptions
                {
                    TypeInfoResolver = new DefaultJsonTypeInfoResolver()
                };
            }
            public ProviderBuilder WithContactInfo(ContactInfo contactInfo)
            {
                _serviceProvider.ContactInfo = contactInfo;
                return this;
            }
            public ProviderBuilder WithAddress(Address address)
            {
                _serviceProvider.Address = JsonDocument.Parse(JsonSerializer.Serialize(address, _options));
                return this;
            }

            public ProviderBuilder WithServiceTags(IEnumerable<string> serviceTags)
            {
                _serviceProvider.ServiceTags = serviceTags.ToList();
                return this;
            }
            public ProviderBuilder WithServiceCategories(IEnumerable<string> serviceCategories)
            {
                _serviceProvider.ServiceCategories = serviceCategories.ToList();
                return this;
            }
            public ProviderBuilder WithProviderServices(List<ProviderService> providerServices)
            {
                _serviceProvider.ProviderServices = providerServices;
                return this;
            }
            public ProviderBuilder WithHighlightedServices(List<ProviderService> highlightedServices)
            {
                _serviceProvider.HighlightedServices = JsonDocument.Parse(JsonSerializer.Serialize(highlightedServices, _options));
                return this;
            }
            public ProviderBuilder WithAverageRating(decimal? averageRating)
            {
                _serviceProvider.AverageRating = averageRating ?? 0.0m;
                return this;
            }
            public ProviderBuilder WithLatestReviews(List<ProviderReview> latestReviews)
            {
                _serviceProvider.LatestReviews = latestReviews is not null ? JsonDocument.Parse(JsonSerializer.Serialize(latestReviews, _options)) : default;
                return this;
            }
            public ProviderBuilder WithCustomersServed(int customersServed)
            {
                _serviceProvider.CustomersServed = customersServed;
                return this;
            }
            public Provider Build()
            {
                return _serviceProvider;
            }
        }
    }
}
