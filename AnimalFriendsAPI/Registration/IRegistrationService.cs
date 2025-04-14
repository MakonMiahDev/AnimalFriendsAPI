using AnimalFriends.Models;

namespace AnimalFriends.Registration
{
    public interface IRegistrationService
    {
        Task<int> RegisterCustomer(CustomerRegistration registration);
    }
}
