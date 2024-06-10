using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Service
{
    public class RegistrationService : IRegistrationService
    {
        private readonly ApplicationDbContext _context;

        public RegistrationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RegistrationModel>> GetAllRegistrationsAsync()
        {
            return await _context.Registrations
                                 .Include(r => r.Event)
                                 .Include(r => r.Participant)
                                 .ToListAsync();
        }

        public async Task<RegistrationModel> GetRegistrationByIdAsync(int id)
        {
            return await _context.Registrations
                                 .Include(r => r.Event)
                                 .Include(r => r.Participant)
                                 .FirstOrDefaultAsync(r => r.RegistrationId == id);
        }

        public async Task<RegistrationModel> CreateRegistrationAsync(RegistrationModel registrationModel)
        {
            _context.Registrations.Add(registrationModel);
            await _context.SaveChangesAsync();
            return registrationModel;
        }

        public async Task<RegistrationModel> UpdateRegistrationAsync(RegistrationModel registrationModel)
        {
            _context.Entry(registrationModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistrationExists(registrationModel.RegistrationId))
                    return null;
                else
                    throw;
            }

            return registrationModel;
        }

        public async Task<bool> DeleteRegistrationAsync(int id)
        {
            var registrationModel = await _context.Registrations.FindAsync(id);
            if (registrationModel == null)
                return false;

            _context.Registrations.Remove(registrationModel);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool RegistrationExists(int id)
        {
            return _context.Registrations.Any(r => r.RegistrationId == id);
        }
    }
}
