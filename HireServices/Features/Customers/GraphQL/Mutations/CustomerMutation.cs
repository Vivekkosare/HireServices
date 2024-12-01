using HireServices.Features.Customers.Commands;
using HireServices.Features.Customers.Domain.Entities;
using HireServices.Features.Customers.GraphQL.Inputs;
using HotChocolate;
using MediatR;

namespace HireServices.Features.Customers.GraphQL.Mutations
{
    public class CustomerMutation
    {
        public async Task<Customer> CreateCustomerAsync([Service] IMediator mediator,
            //[GraphQLType(typeof(CustomerInput))] 
        CustomerInput input)
        {
            return await mediator.Send(new CreateCustomerCommand(input));
        }
    }
}
