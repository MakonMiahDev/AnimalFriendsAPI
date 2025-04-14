using AnimalFriends.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalFriends
{
    // DbContext
    public class RegistrationContext : DbContext
    {
        public RegistrationContext(DbContextOptions<RegistrationContext> options) : base(options) { }
        public DbSet<CustomerRegistration> CustomerRegistrations { get; set; }
    }
}
