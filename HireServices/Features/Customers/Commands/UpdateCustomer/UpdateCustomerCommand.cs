using HireServices.Features.Customers.Domain.Entities;
using HireServices.Features.Customers.GraphQL.Inputs;
using MediatR;

namespace HireServices.Features.Customers.Commands.UpdateCustomer
{
    public record UpdateCustomerCommand(Guid CustomerId, CustomerInput CustomerInput) : IRequest<Customer>
    {
    }
}
