using System.Text.Json;
using HireServices.Features.ServiceProviders.Domain.AggregateRoots;

public class ServicesProviderResolvers
{
    public List<Service> GetServices(ServicesProvider provider)
    {
        if (provider.Services == null)
        {
            return new List<Service>();
        }
        if (provider.Services.RootElement.ValueKind == JsonValueKind.Undefined)
        {
            return new List<Service>();
        }
        return JsonSerializer.Deserialize<List<Service>>(provider.Services.RootElement.GetRawText());
    }
}