using HireServices.Features.Customers.Domain.Entities;

namespace HireServices.Features.Customers.Services
{
    public interface ICustomerService
    {
        public Task<List<Customer>> GetCustomersAsync(int pageSize);
        public Task<Customer> GetCustomerAsync(Guid customerId);
        public Task<Customer> CreateCustomerAsync(Customer customer);
        public Task<Customer> UpdateCustomerAsync(Customer customer);
        public Task DeleteCustomerAsync(Guid customerId);
    }
}
