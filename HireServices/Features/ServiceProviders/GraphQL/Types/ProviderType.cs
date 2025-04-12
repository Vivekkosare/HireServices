using HireServices.Domain.Types;
using HireServices.Features.ServiceProviders.Domain.Entities;

namespace HireServices.Features.ServiceProviders.GraphQL.Types
{
    public class ProviderType :ObjectType<Provider>
    {
        protected override void Configure(IObjectTypeDescriptor<Provider> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(sp => sp.Id).Type<NonNullType<IdType>>();
            descriptor.Field(sp => sp.ContactInfo).Type<NonNullType<ContactInfoType>>();
            descriptor.Field(sp => sp.Address).Type<NonNullType<AddressType>>();
            descriptor.Field(sp => sp.ServiceTags).Type<NonNullType<ListType<StringType>>>();
        }
    }
}
