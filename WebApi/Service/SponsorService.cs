using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Service
{
    public class SponsorService : ISponsorService
    {
        private readonly ApplicationDbContext _context;

        public SponsorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SponsorModel>> GetAllSponsorsAsync()
        {
            return await _context.Sponsors
                                 .Include(s => s.SponsoredEvents)
                                 .ToListAsync();
        }

        public async Task<SponsorModel> GetSponsorByIdAsync(int id)
        {
            return await _context.Sponsors
                                 .Include(s => s.SponsoredEvents)
                                 .FirstOrDefaultAsync(s => s.SponsorId == id);
        }

        public async Task<SponsorModel> CreateSponsorAsync(SponsorModel sponsorModel)
        {
            _context.Sponsors.Add(sponsorModel);
            await _context.SaveChangesAsync();
            return sponsorModel;
        }

        public async Task<SponsorModel> UpdateSponsorAsync(SponsorModel sponsorModel)
        {
            _context.Sponsors.Update(sponsorModel);
            await _context.SaveChangesAsync();
            return sponsorModel;
        }

        public async Task DeleteSponsorAsync(int id)
        {
            var sponsorModel = await _context.Sponsors.FindAsync(id);
            if (sponsorModel != null)
            {
                _context.Sponsors.Remove(sponsorModel);
                await _context.SaveChangesAsync();
            }
        }
    }

}
