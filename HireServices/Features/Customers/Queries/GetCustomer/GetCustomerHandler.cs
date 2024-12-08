using HireServices.Features.Customers.Domain.Entities;
using HireServices.Features.Customers.Services;
using MediatR;

namespace HireServices.Features.Customers.Queries.GetCustomer
{
    public class GetCustomerHandler : IRequestHandler<GetCustomerQuery, Customer>
    {
        private readonly ICustomerService _customerService;

        public GetCustomerHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public async Task<Customer> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerService.GetCustomerAsync(request.customerId);
            return customer;
        }
    }
}
