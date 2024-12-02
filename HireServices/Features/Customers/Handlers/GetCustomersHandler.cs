using HireServices.Features.Customers.Domain.Entities;
using HireServices.Features.Customers.DTOs;
using HireServices.Features.Customers.Extensions;
using HireServices.Features.Customers.Queries;
using HireServices.Features.Customers.Services;
using MediatR;

namespace HireServices.Features.Customers.Handlers
{
    public class GetCustomersHandler : IRequestHandler<GetCustomersQuery, List<CustomerOutput>>
    {
        private readonly ICustomerService _customerService;

        public GetCustomersHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public async Task<List<CustomerOutput>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerService.GetCustomersAsync(request.PageSize);
            return customers?.Select(c => c.ToCustomerOutput()).ToList() ?? new List<CustomerOutput>();
        }
    }
}
