using HireServices.Features.Customers.Domain.Entities;
using HireServices.Features.Customers.Queries;
using MediatR;

namespace HireServices.Features.Customers.Handlers
{
    public class GetCustomersHandler : IRequestHandler<GetCustomersQuery, List<Customer>>
    {
        public Task<List<Customer>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
