using HireServices.Common.DTOs;
using HireServices.Common.Extensions;
using HireServices.Common.ValueObjects;
using HireServices.Features.ServiceProviders.Domain.Entities;
using HireServices.Features.ServiceProviders.DTOs;
using System.Text.Json;

namespace HireServices.Features.ServiceProviders.Domain.Builders
{
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
        public ProviderOutputBuilder WithHighlightedServices(Provider provider)
        {
            var highlightedServices = provider.HighlightedServices;
            if (highlightedServices is not null)
            {
                List<ProviderService> providerServices = JsonSerializer.Deserialize<List<ProviderService>>(highlightedServices.RootElement.GetRawText());
                _serviceProviderOutput.HighlightedServices = providerServices.Select(service =>
                    new ProviderServiceOutputBuilder()
                        //.WithId(service.Id ?? Guid.Empty) // Fix for CS1503
                        .WithId(service.Id) // Fix for CS1503
                        .WithProviderId(provider.Id)
                        .WithName(service.Name)
                        .WithDescription(service.Description)
                        .WithPrice(service.Price)
                        .WithCurrency(service.Currency)
                        .WithDuration(service.Duration)
                        .WithCategory(service.Category)
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
