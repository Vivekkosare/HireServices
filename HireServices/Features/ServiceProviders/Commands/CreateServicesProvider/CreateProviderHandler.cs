using HireServices.Domain.Common;
using HireServices.Features.ServiceProviders.Data;
using HireServices.Features.ServiceProviders.Domain.AggregateRoots;
using HireServices.Features.ServiceProviders.DTOs;
using HireServices.Features.ServiceProviders.Extensions;
using HireServices.Features.ServiceProviders.Services;
using MediatR;

namespace HireServices.Features.ServiceProviders.Commands.CreateServicesProvider
{
    public class CreateProviderHandler : IRequestHandler<CreateProviderCommand, ResultResponse<ProviderOutput>>
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
        public async Task<ResultResponse<ProviderOutput>> Handle(CreateProviderCommand request, CancellationToken cancellationToken)
        {
            ResultResponse<ProviderOutput> provider = null;
            using (var transaction = await _providerDbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    //Check if the service provider exist in the database?
                    var serviceProviderExist = await _providerService.GetProviderByPhoneNumberAsync(request.Input.ContactInfoInput.PhoneNumber);
                    if (serviceProviderExist is not null)
                    {
                        //throw new Exception("Service provider already exist");
                        return ResultResponse<ProviderOutput>.Fail("Service provider already exist", System.Net.HttpStatusCode.Conflict);
                    }
                    //All services for provider
                    var providerServicesInput = request.Input.ServicesInput;
                    List<string> serviceCategories = providerServicesInput.Select(x => x.CategoryInput.Name).ToList();

                    //Fetch the first 3 services (those will be the highlighted services)
                    request.Input.ServicesInput = request.Input.ServicesInput.Take(3).ToList();

                    string tags = string.Empty;
                    var serviceProvider = request.Input.ToServiceProvider();
                    List<string> servicesTagsList = request.Input.ServicesInput.Select(x => x.Name).ToList();
                    //foreach (var serviceTag in servicesTagsList)
                    //{
                    //    tags = string.Join(", ", serviceTag);
                    //}
                    serviceProvider.ServiceTags = servicesTagsList;
                    serviceProvider.ServiceCategories = serviceCategories;
                    //Adds the provider profile in the provider table
                    var providerCreated = await _providerService.CreateProviderAsync(request.Input.ToServiceProvider());
                    if (providerCreated == null)
                    {
                        var msg = "An error occured while creating provider";
                        _logger.LogError(msg);
                        return ResultResponse<ProviderOutput>.Fail(msg, System.Net.HttpStatusCode.Conflict);
                        //throw new Exception(msg);
                    }
                    provider.Value = providerCreated.ToProviderOutput();

                    var providerServices = providerServicesInput.ToProviderServices();

                    //Adds the services into provider services table
                    providerServices.ForEach(x => x.ProviderId = providerCreated.Id);
                    providerServices = await _providerService.BulkCreateProviderServicesAsync(providerServices);

                    List<ProviderServiceOutput> providerServiceOutputs = providerServices.ToProviderServiceOutputList();

                    await transaction.CommitAsync();
                    provider.Value.HighlightedServices = providerServiceOutputs;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    _logger.LogError(ex, "An error occured while creating provider");
                    return ResultResponse<ProviderOutput>.Fail(ex.Message, System.Net.HttpStatusCode.InternalServerError);
                    //throw new Exception($"An error occured while creating provider: {ex.Message}");
                }

            }

            return provider;
        }
    }
}
