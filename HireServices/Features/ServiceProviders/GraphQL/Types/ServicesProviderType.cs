using HireServices.Domain.Types;
using HireServices.Features.ServiceProviders.Domain.AggregateRoots;

namespace HireServices.Features.ServiceProviders.GraphQL.Types
{
    public class ServicesProviderType :ObjectType<ServicesProvider>
    {
        protected override void Configure(IObjectTypeDescriptor<ServicesProvider> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(sp => sp.Id).Type<NonNullType<IdType>>();
            descriptor.Field(sp => sp.ContactInfo).Type<NonNullType<ContactInfoType>>();
            descriptor.Field(sp => sp.Services).Type<NonNullType<ListType<>>>
        }
    }
}
