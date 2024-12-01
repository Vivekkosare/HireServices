using HireServices.Features.Customers.Domain.Entities;
using MediatR;

namespace HireServices.Features.Customers.Queries
{
    public record GetCustomerQuery(Guid customerId) : IRequest<Customer>
    {
    }
}
