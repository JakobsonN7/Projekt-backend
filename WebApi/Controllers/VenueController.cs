using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Service;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VenueController : ControllerBase
    {
        private readonly IVenueService _venueService;

        public VenueController(IVenueService venueService)
        {
            _venueService = venueService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVenues()
        {
            var venues = await _venueService.GetAllVenuesAsync();
            return Ok(venues);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVenueById(int id)
        {
            var venue = await _venueService.GetVenueByIdAsync(id);
            if (venue == null)
                return NotFound();
            return Ok(venue);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVenue([FromBody] VenueModel venueModel)
        {
            var venue = await _venueService.CreateVenueAsync(venueModel);
            return CreatedAtAction(nameof(GetVenueById), new { id = venue.VenueId }, venue);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVenue(int id, [FromBody] VenueModel venueModel)
        {
            if (id != venueModel.VenueId)
                return BadRequest();

            await _venueService.UpdateVenueAsync(venueModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenue(int id)
        {
            await _venueService.DeleteVenueAsync(id);
            return NoContent();
        }
    }

}
