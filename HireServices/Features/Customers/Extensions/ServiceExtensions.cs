﻿using HireServices.Features.ServiceProviders.Domain.AggregateRoots;
using HireServices.Features.ServiceProviders.GraphQL.Inputs;

namespace HireServices.Features.Customers.Extensions
{
    public static class ServiceExtensions
    {
        public static ProviderService ToService(ProviderServiceInput serviceInput)
        {
            return new ProviderService.ProviderServiceBuilder()
                .WithId(serviceInput.Id)
                .WithCategory(serviceInput.CategoryInput)
                .WithPrice(serviceInput.Price)
                .WithDescription(serviceInput.Description)
                .WithDuration(serviceInput.Duration)
                .WithName(serviceInput.Name)
                .Build();
        }
    }
}
