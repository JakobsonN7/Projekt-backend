using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Service;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParticipantController : ControllerBase
    {
        private readonly IParticipantService _participantService;

        public ParticipantController(IParticipantService participantService)
        {
            _participantService = participantService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllParticipants()
        {
            var participants = await _participantService.GetAllParticipantsAsync();
            return Ok(participants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetParticipantById(int id)
        {
            var participant = await _participantService.GetParticipantByIdAsync(id);
            if (participant == null)
                return NotFound();
            return Ok(participant);
        }

        [HttpPost]
        public async Task<IActionResult> CreateParticipant([FromBody] ParticipantModel participantModel)
        {
            var participant = await _participantService.CreateParticipantAsync(participantModel);
            return CreatedAtAction(nameof(GetParticipantById), new { id = participant.ParticipantId }, participant);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateParticipant(int id, [FromBody] ParticipantModel participantModel)
        {
            if (id != participantModel.ParticipantId)
                return BadRequest();

            await _participantService.UpdateParticipantAsync(participantModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipant(int id)
        {
            await _participantService.DeleteParticipantAsync(id);
            return NoContent();
        }
    }

}
