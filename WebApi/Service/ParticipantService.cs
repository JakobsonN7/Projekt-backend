using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Service
{
    public class ParticipantService : IParticipantService
    {
        private readonly ApplicationDbContext _context;

        public ParticipantService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ParticipantModel>> GetAllParticipantsAsync()
        {
            return await _context.Participants
                                 .Include(p => p.Registrations)
                                 .ToListAsync();
        }

        public async Task<ParticipantModel> GetParticipantByIdAsync(int id)
        {
            return await _context.Participants
                                 .Include(p => p.Registrations)
                                 .FirstOrDefaultAsync(p => p.ParticipantId == id);
        }

        public async Task<ParticipantModel> CreateParticipantAsync(ParticipantModel participantModel)
        {
            _context.Participants.Add(participantModel);
            await _context.SaveChangesAsync();
            return participantModel;
        }

        public async Task<ParticipantModel> UpdateParticipantAsync(ParticipantModel participantModel)
        {
            _context.Participants.Update(participantModel);
            await _context.SaveChangesAsync();
            return participantModel;
        }

        public async Task DeleteParticipantAsync(int id)
        {
            var participantModel = await _context.Participants.FindAsync(id);
            if (participantModel != null)
            {
                _context.Participants.Remove(participantModel);
                await _context.SaveChangesAsync();
            }
        }
    }

}
