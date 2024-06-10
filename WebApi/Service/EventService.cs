using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Services
{
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext _context;

        public EventService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EventModel>> GetAllEventsAsync()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<EventModel> GetEventByIdAsync(int id)
        {
            return await _context.Events.FindAsync(id);
        }

        public async Task<EventModel> CreateEventAsync(EventModel eventModel)
        {
            _context.Events.Add(eventModel);
            await _context.SaveChangesAsync();
            return eventModel;
        }

        public async Task<EventModel> UpdateEventAsync(EventModel eventModel)
        {
            _context.Entry(eventModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(eventModel.EventId))
                    return null;
                else
                    throw;
            }

            return eventModel;
        }

        public async Task<bool> DeleteEventAsync(int id)
        {
            var eventModel = await _context.Events.FindAsync(id);
            if (eventModel == null)
                return false;

            _context.Events.Remove(eventModel);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.EventId == id);
        }
    }
}
