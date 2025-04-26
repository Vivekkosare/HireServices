using HireServices.Features.Customers.DTOs;
using HireServices.Features.Customers.Extensions;
using HireServices.Features.Customers.Inputs;
using HireServices.Features.Customers.Services;
using MediatR;

namespace HireServices.Features.Customers.Mutations.Handlers
{
    public record UpdateCustomerCommand(Guid CustomerId, CustomerInput CustomerInput) : IRequest<CustomerOutput>
    {
    }
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
            customerToBeUpdated.ContactInfo = customer.ContactInfo;
            customerToBeUpdated.Addresses = customer.Addresses;
            customerToBeUpdated.UpdatedAt = DateTime.UtcNow;

            var updatedCustomer = await _customerService.UpdateCustomerAsync(customerToBeUpdated);
            return updatedCustomer.ToCustomerOutput();
        }
    }
}
