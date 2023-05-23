using Microsoft.EntityFrameworkCore;
using SupersHerosCRM.Controllers;
using SupersHerosCRM.Data;
using SupersHerosCRM.Models;

namespace SupersHerosCRM.Services;

public class EventService : IEventService
{
    private readonly SupersHerosCRMDbContext _context;
    private readonly ILogger<EventController> _logger;

    public async Task<IEnumerable<Events>?> GetEventsAsync()
    {
        try
        {
            return await _context.Events.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    public async Task<Events?> GetEventAsync(int id, bool includeRelations = true)
    {
        try
        {
            if (includeRelations)
                return await _context.Events
                    .Include(c => c.Incident)
                    .FirstOrDefaultAsync(c => c.Id == id);

            return await _context.Events.FindAsync(id);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    public async Task<Events?> AddEventAsync(Events events)
    {
        try
        {
            _context.Events.Add(events);


            await _context.SaveChangesAsync();
            return events;
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }
}

public interface IEventService
{
    Task<IEnumerable<Events>?> GetEventsAsync();
    Task<Events?> GetEventAsync(int id, bool includeRelations = true);
    Task<Events?> AddEventAsync(Events events);
    
    
}