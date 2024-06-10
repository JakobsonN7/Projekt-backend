using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Services
{
    public interface IEventService
    {
        Task<IEnumerable<EventModel>> GetAllEventsAsync();
        Task<EventModel> GetEventByIdAsync(int id);
        Task<EventModel> CreateEventAsync(EventModel eventModel);
        Task<EventModel> UpdateEventAsync(EventModel eventModel);
        Task<bool> DeleteEventAsync(int id);
    }
}
