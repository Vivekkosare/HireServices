using HireServices.Features.ServiceProviders.Data;
using HireServices.Features.ServiceProviders.Domain.AggregateRoots;
using HireServices.Features.ServiceProviders.DTOs;
using HireServices.Features.ServiceProviders.Extensions;
using HireServices.Features.ServiceProviders.Services;
using MediatR;

namespace HireServices.Features.ServiceProviders.Commands.CreateServicesProvider
{
    public class CreateProviderHandler : IRequestHandler<CreateProviderCommand, ProviderOutput>
    {
        private readonly IProviderServicesService _providerService;
        private readonly ProviderDbContext _providerDbContext;

        public CreateProviderHandler(IProviderServicesService providerService,
            ProviderDbContext providerDbContext)
        {
            _providerService = providerService;
            _providerDbContext = providerDbContext;
        }
        public async Task<ProviderOutput> Handle(CreateProviderCommand request, CancellationToken cancellationToken)
        {
            ProviderOutput provider = null;
            using (var transaction = await _providerDbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    //All services for provider
                    var providerServicesInput = request.Input.ServicesInput;

                    //Fetch the first 3 services (those will be the highlighted services)
                    request.Input.ServicesInput = request.Input.ServicesInput.Take(3).ToList();

                    //Adds the provider profile in the provider table
                    var providerCreated = await _providerService.CreateProviderAsync(request.Input.ToServiceProvider());
                    if (providerCreated == null)
                    {
                        throw new Exception("Error creating services provider");
                    }
                    provider = providerCreated.ToProviderOutput();

                    var providerServices = providerServicesInput.ToProviderServices();

                    //Adds the services into provider services table
                    List<ProviderService> providerServicesCreated = new List<ProviderService>();
                    foreach (var providerService in providerServices)
                    {
                        providerService.ProviderId = providerCreated.Id;
                        var providerServiceCreated = await _providerService.CreateProviderServiceAsync(providerService);
                        providerServicesCreated.Add(providerServiceCreated);
                    }

                    //List<ProviderServiceOutput> providerServiceOutputs = providerServicesCreated.ToProviderServiceOutputList();


                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }

            }

            return provider;
        }
    }
}
