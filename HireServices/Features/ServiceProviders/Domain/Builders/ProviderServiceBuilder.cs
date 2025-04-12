using HireServices.Features.ServiceProviders.Domain.Entities;
using HireServices.Features.ServiceProviders.GraphQL.Inputs;
using System.Text.Json;

namespace HireServices.Features.ServiceProviders.Domain.Builders
{
    public class ProviderServiceBuilder
    {
        private ProviderService _service;
        public ProviderServiceBuilder()
        {
            _service = new ProviderService();
        }

        //public ProviderServiceBuilder WithId(Guid? id)
        //{
        //    if (id is null)
        //    {
        //        _service.Id = Guid.NewGuid();
        //    }
        //    else if (id.HasValue)
        //    {
        //        _service.Id = id;
        //    }
        //    return this;
        //}

        public ProviderServiceBuilder WithName(string name)
        {
            _service.Name = name;
            return this;
        }
        public ProviderServiceBuilder WithDescription(string description)
        {
            _service.Description = description;
            return this;
        }
        public ProviderServiceBuilder WithPrice(decimal price)
        {
            _service.Price = price;
            return this;
        }

        public ProviderServiceBuilder WithDuration(string duration)
        {
            if (string.IsNullOrEmpty(duration))
            {
                _service.Duration = default;
            }
            else
            {
                _service.Duration = TimeSpan.Parse(duration);
            }
            return this;
        }

        public ProviderServiceBuilder WithCategory(CategoryInput categoryInput)
        {
            _service.Category = JsonDocument.Parse(JsonSerializer.Serialize(categoryInput));
            return this;
        }
        public ProviderService Build()
        {
            return _service;
        }

    }
}
