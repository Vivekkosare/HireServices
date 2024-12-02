using HireServices.Features.Customers.Domain.Entities;
using HireServices.Features.Customers.DTOs;
using MediatR;

namespace HireServices.Features.Customers.Queries
{
    public record GetCustomersQuery(int PageSize) : IRequest<List<CustomerOutput>>
    {

    }
}
