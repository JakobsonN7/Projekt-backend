using WebApi.Models;

namespace WebApi.Service
{
    public interface IVenueService
    {
        Task<IEnumerable<VenueModel>> GetAllVenuesAsync();
        Task<VenueModel> GetVenueByIdAsync(int id);
        Task<VenueModel> CreateVenueAsync(VenueModel venueModel);
        Task<VenueModel> UpdateVenueAsync(VenueModel venueModel);
        Task DeleteVenueAsync(int id);
    }
}
