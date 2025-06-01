using HireServices.Features.ServiceProviders.Data;
using HireServices.Features.ServiceProviders.DTOs;
using HireServices.Features.ServiceProviders.Extensions;
using HireServices.Features.ServiceProviders.Inputs;
using HireServices.Features.ServiceProviders.Services;
using MediatR;
using System.Text.Json;

namespace HireServices.Features.ServiceProviders.Mutations.Handlers
{
    public record CreateProviderCommand(ProviderInput Input) : IRequest<ProviderOutput>
    {
    }
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
                    List<string> serviceCategories = providerServicesInput.Select(x => x.CategoryInput.Name).Distinct().ToList();

                    //Fetch the first 3 services (those will be the highlighted services)
                    request.Input.ServicesInput = request.Input.ServicesInput.Distinct().Take(3).ToList();

                    var serviceProvider = request.Input.ToServiceProvider();
                    List<string> servicesTagsList = request.Input.ServicesInput.Select(x => x.Name).ToList();

                    serviceProvider.ServiceTags = servicesTagsList;
                    serviceProvider.ServiceCategories = serviceCategories;

                    //Adds the provider profile in the provider table
                    var providerCreated = await _providerService.CreateProviderAsync(serviceProvider);
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
                    var providerServicesCreated = await _providerService.BulkCreateProviderServicesAsync(providerServices);

                    // Take the first 3 services to be highlighted
                    // and update the provider with these services
                    var highlightedServices = providerServicesCreated.Take(3).ToList();
                    highlightedServices.ForEach(x => x.ProviderId = providerCreated.Id);

                    providerCreated.HighlightedServices = JsonDocument.Parse(JsonSerializer.Serialize(highlightedServices));

                    await _providerDbContext.SaveChangesAsync();


                    List<ProviderServiceOutput> providerServiceOutputs = providerServicesCreated.ToProviderServiceOutputList();
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
