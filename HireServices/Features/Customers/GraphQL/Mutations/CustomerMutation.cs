using HireServices.Features.Customers.Commands.CreateCustomer;
using HireServices.Features.Customers.Commands.UpdateCustomer;
using HireServices.Features.Customers.Domain.Entities;
using HireServices.Features.Customers.DTOs;
using HireServices.Features.Customers.GraphQL.Inputs;
using MediatR;

namespace HireServices.Features.Customers.GraphQL.Mutations
{
    [ExtendObjectType(Name = "Mutation")]
    public class CustomerMutationExtension : CustomerMutation
    {

    }
    public class CustomerMutation
    {
        public async Task<CustomerOutput> CreateCustomerAsync([Service] IMediator mediator,
        //[GraphQLType(typeof(CustomerInput))] 
        CustomerInput input)
        {
            return await mediator.Send(new CreateCustomerCommand(input));
        }

        public async Task<CustomerOutput> UpdateCustomerAsync([Service] IMediator mediator,
            [GraphQLType(typeof(CustomerInput))] CustomerInput input, [GraphQLType(typeof(Guid))] Guid customerId)
        {
            return await mediator.Send(new UpdateCustomerCommand(customerId, input));
        }
    }
}
