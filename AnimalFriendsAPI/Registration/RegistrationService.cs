
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
            _context.CustomerRegistrations.Add(registration);
            await _context.SaveChangesAsync();

            return registration.CustomerId;
        }

    }
}
