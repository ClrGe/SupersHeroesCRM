using Microsoft.EntityFrameworkCore;
using SupersHerosCRM.Controllers;
using SupersHerosCRM.Data;
using SupersHerosCRM.Models;

namespace SupersHerosCRM.Services;

public class EventService : IEventService
{
    private readonly SupersHerosCRMDbContext _context;
    private readonly ILogger<EventController> _logger;

    public EventService(SupersHerosCRMDbContext context, ILogger<EventController> logger)
    {
        _context = context;
        _logger = logger;
    }
    public async Task<IEnumerable<Event>?> GetEventsAsync()
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

    public async Task<Event?> GetEventAsync(int id, bool includeRelations = true)
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

    public async Task<Event?> AddEventAsync(Event @event)
    {
        try
        {
            _context.Events.Add(@event);


            await _context.SaveChangesAsync();
            return @event;
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
    Task<IEnumerable<Event>?> GetEventsAsync();
    Task<Event?> GetEventAsync(int id, bool includeRelations = true);
    Task<Event?> AddEventAsync(Event @event);
    
    
}