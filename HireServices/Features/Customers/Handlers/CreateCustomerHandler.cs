using HireServices.Features.Customers.Commands;
using HireServices.Features.Customers.Domain.Entities;
using HireServices.Features.Customers.Extensions;
using HireServices.Features.Customers.Services;
using MediatR;

namespace HireServices.Features.Customers.Handlers
{
    public class CreateCustomerHandler(ICustomerService customerService) : IRequestHandler<CreateCustomerCommand, Customer>
    {
        private readonly ICustomerService customerService = customerService;

        public Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            // Convert the input to a Customer object
            var customer = request.Input.ToCustomer();
            return customerService.CreateCustomerAsync(customer);
        }
    }
}
