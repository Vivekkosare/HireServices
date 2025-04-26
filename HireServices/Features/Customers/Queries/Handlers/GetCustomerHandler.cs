using HireServices.Features.Customers.DTOs;
using HireServices.Features.Customers.Extensions;
using HireServices.Features.Customers.Services;
using MediatR;

namespace HireServices.Features.Customers.Queries.Handlers
{
    public record GetCustomerQuery(Guid customerId) : IRequest<CustomerOutput>
    {
    }
    public class GetCustomerHandler : IRequestHandler<GetCustomerQuery, CustomerOutput>
    {
        private readonly ICustomerService _customerService;

        public GetCustomerHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public async Task<CustomerOutput> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerService.GetCustomerAsync(request.customerId);
            return customer.ToCustomerOutput();
        }
    }
}
