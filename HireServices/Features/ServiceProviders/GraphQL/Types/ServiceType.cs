using HireServices.Domain.Types;
using HireServices.Features.ServiceProviders.Domain.AggregateRoots;

namespace HireServices.Features.ServiceProviders.GraphQL.Types
{
    public class ServiceType : ObjectType<ServicesProviderService>
    {
        protected override void Configure(IObjectTypeDescriptor<ServicesProviderService> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(s => s.Id).Type<IdType>();
            descriptor.Field(s => s.ServiceProviderId).Type<NonNullType<IdType>>();
            descriptor.Field(s => s.Name).Type<NonNullType<StringType>>();
            descriptor.Field(s => s.Description).Type<StringType>();
            descriptor.Field(s => s.Price).Type<NonNullType<DecimalType>>();
            descriptor.Field(s => s.Duration).Type<NonNullType<TimeSpanType>>();
        }
    }
}
