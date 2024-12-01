using HireServices.Features.Customers.Domain.Entities;
using MediatR;

namespace HireServices.Features.Customers.Queries
{
    public record GetCustomersQuery(int PageSize) : IRequest<List<Customer>>
    {

    }
}
