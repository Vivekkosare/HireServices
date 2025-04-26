using HireServices.Common.Types;
using HireServices.Features.Customers.Domain.Entities;
using HireServices.Features.Customers.Resolvers;
using HotChocolate.Types;

namespace HireServices.Features.Customers.Types
{
    public class CustomerType : ObjectType<Customer>
    {
        protected override void Configure(IObjectTypeDescriptor<Customer> descriptor)
        {
            descriptor.Field(c => c.Id)
                .Type<NonNullType<IdType>>();

            descriptor.Field(c => c.ContactInfo)
                //.ResolveWith<CustomerResolvers>(r => r.GetContactInfo(default!))
                .Type<NonNullType<ContactInfoType>>();

            descriptor.Field(c => c.Addresses)
                .ResolveWith<CustomerResolvers>(r => r.GetAddresses(default!))
                .Type<ListType<AddressType>>();
        }
    }
}
