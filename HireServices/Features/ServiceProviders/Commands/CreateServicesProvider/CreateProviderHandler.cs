﻿using HireServices.Features.ServiceProviders.Data;
using HireServices.Features.ServiceProviders.DTOs;
using HireServices.Features.ServiceProviders.Extensions;
using HireServices.Features.ServiceProviders.Services;
using MediatR;
using System.Text.Json;

namespace HireServices.Features.ServiceProviders.Commands.CreateServicesProvider
{
    public class CreateProviderHandler : IRequestHandler<CreateProviderCommand, ProviderOutput>
    {
        private readonly IProviderServicesService _providerService;
        private readonly ProviderDbContext _providerDbContext;
        private readonly ILogger<CreateProviderHandler> _logger;

        public CreateProviderHandler(IProviderServicesService providerService,
            ProviderDbContext providerDbContext,
            ILogger<CreateProviderHandler> logger)
        {
            _providerService = providerService;
            _providerDbContext = providerDbContext;
            _logger = logger;
        }
        public async Task<ProviderOutput> Handle(CreateProviderCommand request, CancellationToken cancellationToken)
        {
            ProviderOutput provider = new ProviderOutput();
            using (var transaction = await _providerDbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    //Check if the service provider exist in the database?
                    var serviceProviderExist = await _providerService.GetProviderByPhoneNumberAsync(request.Input.ContactInfoInput.PhoneNumber);
                    if (serviceProviderExist is not null)
                    {
                        throw new GraphQLException("Service provider already exist");
                    }
                    //All services for provider
                    var providerServicesInput = request.Input.ServicesInput;
                    List<string> serviceCategories = providerServicesInput.Select(x => x.CategoryInput.Name).ToList();

                    //Fetch the first 3 services (those will be the highlighted services)
                    request.Input.ServicesInput = request.Input.ServicesInput.Take(3).ToList();

                    string tags = string.Empty;
                    var serviceProvider = request.Input.ToServiceProvider();
                    List<string> servicesTagsList = request.Input.ServicesInput.Select(x => x.Name).ToList();

                    serviceProvider.ServiceTags = servicesTagsList;
                    serviceProvider.ServiceCategories = serviceCategories;

                    //Adds the provider profile in the provider table
                    var providerCreated = await _providerService.CreateProviderAsync(request.Input.ToServiceProvider());
                    if (providerCreated == null)
                    {
                        var msg = "An error occured while creating provider";
                        _logger.LogError(msg);
                        throw new GraphQLException(msg);
                    }
                    provider = providerCreated.ToProviderOutput();

                    var providerServices = providerServicesInput.ToProviderServices();

                    //Adds the services into provider services table
                    providerServices.ForEach(x => x.ProviderId = providerCreated.Id);
                    providerServices = await _providerService.BulkCreateProviderServicesAsync(providerServices);

                    providerCreated.HighlightedServices = JsonDocument.Parse(JsonSerializer.Serialize(providerServices.Take(3)));
                    _providerDbContext.Providers.Update(providerCreated);

                    
                    List<ProviderServiceOutput> providerServiceOutputs = providerServices.ToProviderServiceOutputList();                    
                    provider.HighlightedServices = providerServiceOutputs.Take(3).ToList();

                    await transaction.CommitAsync();
                    return provider;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    _logger.LogError(ex, "Something happened!!");
                    throw;
                }


            }
        }
    }
}
