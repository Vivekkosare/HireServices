using HireServices.Features.Customers.Domain.Entities;
using HireServices.Features.Customers.DTOs;
using HireServices.Features.Customers.Extensions;
using HireServices.Features.Customers.Services;
using MediatR;

namespace HireServices.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, CustomerOutput>
    {
        private readonly ICustomerService _customerService;

        public UpdateCustomerHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public async Task<CustomerOutput> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = request.CustomerInput.ToCustomer();
            var customerToBeUpdated = await _customerService.GetCustomerAsync(request.CustomerId);
            if (customerToBeUpdated == null)
            {
                throw new Exception("Customer not found");
            }
            customerToBeUpdated = customerToBeUpdated.MapCustomerToUpdate(customer);

            var updatedCustomer = await _customerService.UpdateCustomerAsync(customerToBeUpdated);
            return updatedCustomer.ToCustomerOutput();
        }
    }
}
