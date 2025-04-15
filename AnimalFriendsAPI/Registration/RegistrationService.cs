
using System.Security.Cryptography;
using AnimalFriends.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalFriends.Registration
{
    public class RegistrationService : IRegistrationService
    {

        private readonly RegistrationContext _context;

        public RegistrationService(RegistrationContext context)
        {
            _context = context;
        }

        public async Task<int> RegisterCustomer(CustomerRegistration registration)
        {
            registration.CustomerId = await GenerateUniqueCustomerIdAsync();

            _context.CustomerRegistrations.Add(registration);
            await _context.SaveChangesAsync();

            return registration.CustomerId;
        }

        private async Task<int> GenerateUniqueCustomerIdAsync()
        {
            const int maxAttempts = 10;
            int attempts = 0;

            while (attempts < maxAttempts)
            {
                int customerId = RandomNumberGenerator.GetInt32(100000, 999999);
                bool exists = await _context.CustomerRegistrations.AnyAsync(c => c.CustomerId == customerId);

                if (!exists)
                    return customerId;

                attempts++;
            }

            throw new InvalidOperationException("Failed to generate a unique CustomerId after multiple attempts.");
        }

    }
}
