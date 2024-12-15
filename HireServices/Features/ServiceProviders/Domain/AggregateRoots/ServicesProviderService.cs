using HireServices.Features.ServiceProviders.Domain.ValueObjects;
using HireServices.Features.ServiceProviders.Extensions;
using HireServices.Features.ServiceProviders.GraphQL.Inputs;

namespace HireServices.Features.ServiceProviders.Domain.AggregateRoots
{
    public class ServicesProviderService
    {

        [GraphQLType(typeof(IdType))]
        public Guid? Id { get; set; }
        
        [GraphQLType(typeof(IdType))]
        public Guid ServiceProviderId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
        public Category Category { get; set; }

        public class ServicesProviderServiceBuilder
        {
            private ServicesProviderService _service;
            public ServicesProviderServiceBuilder()
            {
                _service = new ServicesProviderService();
            }

            public ServicesProviderServiceBuilder WithId(Guid? id)
            {
                if (id is null)
                {
                    _service.Id = Guid.NewGuid();
                }
                else if (id.HasValue)
                {
                    _service.Id = id;
                }
                return this;
            }

            public ServicesProviderServiceBuilder WithName(string name)
            {
                _service.Name = name;
                return this;
            }
            public ServicesProviderServiceBuilder WithDescription(string description)
            {
                _service.Description = description;
                return this;
            }
            public ServicesProviderServiceBuilder WithPrice(decimal price)
            {
                _service.Price = price;
                return this;
            }

            public ServicesProviderServiceBuilder WithDuration(string duration)
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

            public ServicesProviderServiceBuilder WithCategory(CategoryInput categoryInput)
            {
                _service.Category = categoryInput.ToCategory();
                return this;
            }
            public ServicesProviderService Build()
            {
                return _service;
            }

        }
    }
}
