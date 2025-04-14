using AnimalFriends.Models;
using AnimalFriends.Registration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnimalFriends.Tests
{
    [TestClass]
    public class RegistrationValidatorTests
    {
        private RegistrationValidator _validator = null!;

        [TestInitialize]
        public void Setup()
        {
            _validator = new RegistrationValidator();
        }

        [TestMethod]
        public void ValidCustomer_PassesValidation()
        {
            var result = _validator.Validate(new CustomerRegistration
            {
                FirstName = "Alice",
                LastName = "Smith",
                PolicyReference = "AB-123456",
                DateOfBirth = DateTime.Today.AddYears(-20),
                Email = "alice123@email.com"
            });

            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void MissingFirstName_FailsValidation()
        {
            var result = _validator.Validate(new CustomerRegistration
            {
                FirstName = "",
                LastName = "Smith",
                PolicyReference = "AB-123456",
                Email = "test123@email.com"
            });

            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void InvalidPolicyReference_FailsValidation()
        {
            var result = _validator.Validate(new CustomerRegistration
            {
                FirstName = "Bob",
                LastName = "Smith",
                PolicyReference = "123456",
                Email = "bob123@email.com"
            });

            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void UnderageCustomer_FailsValidation()
        {
            var result = _validator.Validate(new CustomerRegistration
            {
                FirstName = "Bob",
                LastName = "Smith",
                PolicyReference = "AB-123456",
                DateOfBirth = DateTime.Today.AddYears(-17),
                Email = "bob123@email.com"
            });

            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void NoDobOrEmail_FailsValidation()
        {
            var result = _validator.Validate(new CustomerRegistration
            {
                FirstName = "Jane",
                LastName = "Smith",
                PolicyReference = "AB-123456"
            });

            Assert.IsFalse(result.IsValid);
        }
    }
}
