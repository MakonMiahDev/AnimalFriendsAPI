using AnimalFriends.Models;

namespace AnimalFriends
{
    public interface IRegistrationService
    {
        Task<int> RegisterCustomer(CustomerRegistration registration);
    }
}
