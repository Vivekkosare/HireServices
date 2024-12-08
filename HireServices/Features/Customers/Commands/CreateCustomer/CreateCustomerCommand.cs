using HireServices.Features.Customers.Domain.Entities;
using HireServices.Features.Customers.GraphQL.Inputs;
using MediatR;

namespace HireServices.Features.Customers.Commands.CreateCustomer
{
    public record CreateCustomerCommand(CustomerInput Input) : IRequest<Customer>
    {
    }
}
