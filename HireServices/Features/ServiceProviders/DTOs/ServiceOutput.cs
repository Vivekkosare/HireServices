using HireServices.Features.ServiceProviders.Domain.ValueObjects;

namespace HireServices.Features.ServiceProviders.DTOs
{
    public record ServiceOutput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
        public Category Category { get; set; }
        public ServiceOutput(Guid id, string name, string description, decimal price, TimeSpan duration, Category category)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Duration = duration;
            Category = category;
        }
    }
}
