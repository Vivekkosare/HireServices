using HireServices.Features.Customers.DTOs;
using HireServices.Features.Customers.Inputs;
using HireServices.Features.Customers.Mutations.Handlers;
using MediatR;

namespace HireServices.Features.Customers.Mutations
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
