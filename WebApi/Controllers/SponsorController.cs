using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Service;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SponsorController : ControllerBase
    {
        private readonly ISponsorService _sponsorService;

        public SponsorController(ISponsorService sponsorService)
        {
            _sponsorService = sponsorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSponsors()
        {
            var sponsors = await _sponsorService.GetAllSponsorsAsync();
            return Ok(sponsors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSponsorById(int id)
        {
            var sponsor = await _sponsorService.GetSponsorByIdAsync(id);
            if (sponsor == null)
                return NotFound();
            return Ok(sponsor);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSponsor([FromBody] SponsorModel sponsorModel)
        {
            var sponsor = await _sponsorService.CreateSponsorAsync(sponsorModel);
            return CreatedAtAction(nameof(GetSponsorById), new { id = sponsor.SponsorId }, sponsor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSponsor(int id, [FromBody] SponsorModel sponsorModel)
        {
            if (id != sponsorModel.SponsorId)
                return BadRequest();

            await _sponsorService.UpdateSponsorAsync(sponsorModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSponsor(int id)
        {
            await _sponsorService.DeleteSponsorAsync(id);
            return NoContent();
        }
    }

}
