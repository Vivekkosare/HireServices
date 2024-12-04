using HireServices.Features.ServiceProviders.Domain.ValueObjects;

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
    }
}
