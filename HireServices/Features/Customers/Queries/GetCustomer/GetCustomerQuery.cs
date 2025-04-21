using HireServices.Features.Customers.Domain.Entities;
using HireServices.Features.Customers.DTOs;
using MediatR;

namespace HireServices.Features.Customers.Queries.GetCustomer
{
    public record GetCustomerQuery(Guid customerId) : IRequest<CustomerOutput>
    {
    }
}
