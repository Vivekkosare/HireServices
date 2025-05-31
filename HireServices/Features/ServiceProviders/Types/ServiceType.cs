using HireServices.Features.ServiceProviders.Domain.Entities;

namespace HireServices.Features.ServiceProviders.Types
{
    public class ServiceType : ObjectType<ProviderService>
    {
        protected override void Configure(IObjectTypeDescriptor<ProviderService> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(s => s.Id).Type<IdType>();
            descriptor.Field(s => s.ProviderId).Type<NonNullType<IdType>>();
            descriptor.Field(s => s.Name).Type<NonNullType<StringType>>();
            descriptor.Field(s => s.Description).Type<StringType>();
            descriptor.Field(s => s.Price).Type<NonNullType<DecimalType>>();
            descriptor.Field(s => s.Duration).Type<NonNullType<TimeSpanType>>();
        }
    }
}
