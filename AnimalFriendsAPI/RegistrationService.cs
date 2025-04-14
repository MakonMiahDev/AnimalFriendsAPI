
using AnimalFriends.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalFriends
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
            var random = new Random();
            int customerId;
            bool isUnique = false;
            int maxAttempts = 10; // prevent infinite loops
            int attempts = 0;

            do
            {
                customerId = random.Next(100000, 999999);
                isUnique = !await _context.CustomerRegistrations.AnyAsync(c => c.CustomerId == customerId);
                attempts++;
            }
            while (!isUnique && attempts < maxAttempts);

            if (!isUnique)
            {
                throw new Exception("Failed to generate a unique CustomerId after multiple attempts.");
            }

            registration.CustomerId = customerId;
            _context.CustomerRegistrations.Add(registration);
            await _context.SaveChangesAsync();

            return customerId;
        }

    }
}
