using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Service
{
    public class VenueService : IVenueService
    {
        private readonly ApplicationDbContext _context;

        public VenueService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VenueModel>> GetAllVenuesAsync()
        {
            return await _context.Venues
                                 .Include(v => v.Events)
                                 .ToListAsync();
        }

        public async Task<VenueModel> GetVenueByIdAsync(int id)
        {
            return await _context.Venues
                                 .Include(v => v.Events)
                                 .FirstOrDefaultAsync(v => v.VenueId == id);
        }

        public async Task<VenueModel> CreateVenueAsync(VenueModel venueModel)
        {
            _context.Venues.Add(venueModel);
            await _context.SaveChangesAsync();
            return venueModel;
        }

        public async Task<VenueModel> UpdateVenueAsync(VenueModel venueModel)
        {
            _context.Venues.Update(venueModel);
            await _context.SaveChangesAsync();
            return venueModel;
        }

        public async Task DeleteVenueAsync(int id)
        {
            var venueModel = await _context.Venues.FindAsync(id);
            if (venueModel != null)
            {
                _context.Venues.Remove(venueModel);
                await _context.SaveChangesAsync();
            }
        }
    }

}
