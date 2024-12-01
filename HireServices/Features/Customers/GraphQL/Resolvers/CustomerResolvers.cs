using HireServices.Domain.ValueObjects;
using HireServices.Features.Customers.Domain.Entities;
using System.Text.Json;

namespace HireServices.Features.Customers.GraphQL.Resolvers
{
    public class CustomerResolvers
    {
        //public ContactInfo GetContactInfo(Customer customer)
        //{
        //    return JsonSerializer.Deserialize<ContactInfo>(customer.ContactInfo.ToString());
        //}
        public List<Address> GetAddresses(Customer customer)
        {
            return JsonSerializer.Deserialize<List<Address>>(customer.Addresses.ToString());
        }
    }
}
