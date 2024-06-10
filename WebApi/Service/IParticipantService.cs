using WebApi.Models;

namespace WebApi.Service
{
    public interface IParticipantService
    {
        Task<IEnumerable<ParticipantModel>> GetAllParticipantsAsync();
        Task<ParticipantModel> GetParticipantByIdAsync(int id);
        Task<ParticipantModel> CreateParticipantAsync(ParticipantModel participantModel);
        Task<ParticipantModel> UpdateParticipantAsync(ParticipantModel participantModel);
        Task DeleteParticipantAsync(int id);
    }
}
