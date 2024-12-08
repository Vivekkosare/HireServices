using HireServices.Features.Customers.Domain.Entities;
using HireServices.Features.Customers.DTOs;
using HireServices.Features.Customers.Queries;
using HireServices.Features.Customers.Queries.GetCustomer;
using HireServices.Features.Customers.Queries.GetCustomers;
using HotChocolate;
using MediatR;

namespace HireServices.Features.Customers.GraphQL.Queries
{
    public class CustomerQuery
    {
        public async Task<List<CustomerOutput>> GetCustomers([Service] IMediator mediator, int pageSize = 10)
        {
            return await mediator.Send(new GetCustomersQuery(pageSize));
        }

        public async Task<Customer> GetCustomer([Service] IMediator mediator, Guid customerId)
        {
            return await mediator.Send(new GetCustomerQuery(customerId));
        }
    }
}
