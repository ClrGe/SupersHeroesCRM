using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupersHerosCRM.Data;
using SupersHerosCRM.Models;

namespace SupersHerosCRM.Controllers;

public class EventController: ControllerBase
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
            {
                return await _context.Events
                    .Include(c => c.Heroes)
                    .FirstOrDefaultAsync(c => c.Id == id);
            }

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