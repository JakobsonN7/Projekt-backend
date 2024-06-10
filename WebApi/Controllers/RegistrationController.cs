using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Service;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegistrations()
        {
            var registrations = await _registrationService.GetAllRegistrationsAsync();
            return Ok(registrations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegistrationById(int id)
        {
            var registration = await _registrationService.GetRegistrationByIdAsync(id);
            if (registration == null)
                return NotFound();
            return Ok(registration);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRegistration([FromBody] RegistrationModel registrationModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var registration = await _registrationService.CreateRegistrationAsync(registrationModel);
            return CreatedAtAction(nameof(GetRegistrationById), new { id = registration.RegistrationId }, registration);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRegistration(int id, [FromBody] RegistrationModel registrationModel)
        {
            if (id != registrationModel.RegistrationId)
                return BadRequest();

            var updatedRegistration = await _registrationService.UpdateRegistrationAsync(registrationModel);
            if (updatedRegistration == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistration(int id)
        {
            var deleted = await _registrationService.DeleteRegistrationAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
