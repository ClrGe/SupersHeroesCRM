using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupersHerosCRM.Data;
using SupersHerosCRM.Models;

namespace SupersHerosCRM.Controllers;

public class IncidentController : ControllerBase
{
    private readonly SupersHerosCRMDbContext _context;
    private readonly ILogger<IncidentController> _logger;
    
    public IncidentController(SupersHerosCRMDbContext context, ILogger<IncidentController> logger)
    {
        _context = context;
        _logger = logger;
    }
    
    public async Task<IEnumerable<Incident>?> GetIncidentsAsync()
    {
        try
        {
            return await _context.Incidents.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }
    
    public async Task<Incident?> GetIncidentAsync(int id, bool includeRelations = true)
    {
        try
        {
            if (includeRelations)
            {
                return await _context.Incidents
                    .Include(c => c.Heroes)
                    .FirstOrDefaultAsync(c => c.Id == id);
            }

            return await _context.Incidents.FindAsync(id);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }
        
}