using HireServices.Features.Customers.DTOs;
using HireServices.Features.Customers.Queries.Handlers;
using MediatR;

namespace HireServices.Features.Customers.Queries
{
    [ExtendObjectType(Name = "Query")]
    public class CustomerQueryExtension : CustomerQuery
    {

    }
    public class CustomerQuery
    {
        public async Task<List<CustomerOutput>> GetCustomers([Service] IMediator mediator, int pageSize = 10)
        {
            return await mediator.Send(new GetCustomersQuery(pageSize));
        }

        public async Task<CustomerOutput> GetCustomer([Service] IMediator mediator, Guid customerId)
        {
            return await mediator.Send(new GetCustomerQuery(customerId));
        }
    }
}
