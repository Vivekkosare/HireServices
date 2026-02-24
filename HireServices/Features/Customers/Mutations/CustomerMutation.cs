using HireServices.Features.Customers.DTOs;
using HireServices.Features.Customers.Inputs;
using HireServices.Features.Customers.Mutations.Handlers;
using HotChocolate.Authorization;
using MediatR;

namespace HireServices.Features.Customers.Mutations
{
    [ExtendObjectType(Name = "Mutation")]
    public class CustomerMutationExtension : CustomerMutation
    {

    }

    public class CustomerMutation
    {
        // Requires a valid Firebase Bearer token. HotChocolate will return
        // an AUTH_NOT_AUTHENTICATED error before the resolver runs if missing.
        [Authorize]
        public async Task<CustomerOutput> CreateCustomerAsync([Service] IMediator mediator,
        //[GraphQLType(typeof(CustomerInput))]
        CustomerInput input)
        {
            return await mediator.Send(new CreateCustomerCommand(input));
        }

        [Authorize]
        public async Task<CustomerOutput> UpdateCustomerAsync([Service] IMediator mediator,
            [GraphQLType(typeof(CustomerInput))] CustomerInput input, [GraphQLType(typeof(Guid))] Guid customerId)
        {
            return await mediator.Send(new UpdateCustomerCommand(customerId, input));
        }
    }
}
