using HireServices.Features.ServiceProviders.Domain.ValueObjects;
using HireServices.Features.ServiceProviders.Extensions;
using HireServices.Features.ServiceProviders.GraphQL.Inputs;

namespace HireServices.Features.ServiceProviders.Domain.AggregateRoots
{
    public class Service
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
        public Category Category { get; set; }

        public class ServiceBuilder
        {
            private Service _service;
            public ServiceBuilder()
            {
                _service = new Service();
            }

            public ServiceBuilder WithName(string name)
            {
                _service.Name = name;
                return this;
            }
            public ServiceBuilder WithDescription(string description)
            {
                _service.Description = description;
                return this;
            }
            public ServiceBuilder WithPrice(decimal price)
            {
                _service.Price = price;
                return this;
            }

            public ServiceBuilder WithDuration(TimeSpan duration)
            {
                _service.Duration = duration;
                return this;
            }

            public ServiceBuilder WithCategory(CategoryInput categoryInput)
            {
                _service.Category = categoryInput.ToCategory();
                return this;
            }
            public Service Build()
            {
                return _service;
            }

        }
    }
}
