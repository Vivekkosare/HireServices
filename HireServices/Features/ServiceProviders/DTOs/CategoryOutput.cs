namespace HireServices.Features.ServiceProviders.DTOs
{
    public record CategoryOutput
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public CategoryOutput(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
