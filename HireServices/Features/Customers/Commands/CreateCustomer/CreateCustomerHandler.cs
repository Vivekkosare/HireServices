using HireServices.Features.Customers.Domain.Entities;
using HireServices.Features.Customers.DTOs;
using HireServices.Features.Customers.Extensions;
using HireServices.Features.Customers.Services;
using MediatR;

namespace HireServices.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerHandler(ICustomerService customerService) : IRequestHandler<CreateCustomerCommand, CustomerOutput>
    {
        private readonly ICustomerService _customerService = customerService;

        public async Task<CustomerOutput> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            // Convert the input to a Customer object
            var customer = request.Input.ToCustomer();
            var customerCreated = await _customerService.CreateCustomerAsync(customer);
            return customerCreated.ToCustomerOutput();
        }
    }
}
