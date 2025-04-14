using System.ComponentModel.DataAnnotations;

namespace AnimalFriends.Models
{
    public class CustomerRegistration
    {
        [Key]
        public int CustomerId { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string PolicyReference { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public string? Email { get; set; }
    }
}
