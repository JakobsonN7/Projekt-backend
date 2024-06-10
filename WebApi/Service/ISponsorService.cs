using WebApi.Models;

namespace WebApi.Service
{
    public interface ISponsorService
    {
        Task<IEnumerable<SponsorModel>> GetAllSponsorsAsync();
        Task<SponsorModel> GetSponsorByIdAsync(int id);
        Task<SponsorModel> CreateSponsorAsync(SponsorModel sponsorModel);
        Task<SponsorModel> UpdateSponsorAsync(SponsorModel sponsorModel);
        Task DeleteSponsorAsync(int id);
    }
}
