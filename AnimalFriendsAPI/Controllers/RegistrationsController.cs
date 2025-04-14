using AnimalFriends.Models;
using AnimalFriends.Registration;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace AnimalFriends.Controllers
{
    // Controller
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _service;
        private readonly IValidator<CustomerRegistration> _validator;

        public RegistrationController(IRegistrationService service, IValidator<CustomerRegistration> validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CustomerRegistration request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            try
            {
                int customerId = await _service.RegisterCustomer(request);
                return Ok(new { CustomerId = customerId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while processing your request.", Details = ex.Message });
            }
        }
    }

}
