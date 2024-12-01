using HireServices.Features.Customers.Data;
using HireServices.Features.Customers.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HireServices.Features.Customers.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerDbContext _context;
        public CustomerService(CustomerDbContext context)
        {
            _context = context;
        }
        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            var customerCreated = await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customerCreated.Entity;
        }

        public async Task DeleteCustomerAsync(Guid customerId)
        {
            _context.Customers.Remove(new Customer { Id = customerId });
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> GetCustomerAsync(Guid customerId)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            if (customer == null)
            {
                throw new Exception("Customer not found");
            }
            return customer;
        }

        public async Task<List<Customer>> GetCustomersAsync(int pageSize)
        {
            var customers = await _context.Customers.Take(pageSize).ToListAsync();
            return customers;
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
    }
}
