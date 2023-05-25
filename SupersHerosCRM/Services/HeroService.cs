using Microsoft.EntityFrameworkCore;
using SupersHerosCRM.Controllers;
using SupersHerosCRM.Data;
using SupersHerosCRM.Models;

namespace SupersHerosCRM.Services;

public class HeroService : IHeroService
{
    private readonly SupersHerosCRMDbContext _context;
    private readonly ILogger<HeroController> _logger;

    public HeroService(SupersHerosCRMDbContext context, ILogger<HeroController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IEnumerable<Hero>?> GetHeroesAsync()
    {
        try
        {
            return await _context.Heroes.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    public async Task<Hero?> GetHeroAsync(int id, bool includeRelations = true)
    {
        try
        {
            if (includeRelations)
                return await _context.Heroes
                    .Include(c => c.Incidents)
                    .FirstOrDefaultAsync(c => c.Id == id);

            return await _context.Heroes.FindAsync(id);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    public async Task<Hero?> AddHeroAsync(Hero hero)
    {
        try
        {
            
            /* add related incidents to join table HeroIncident with Hero array of incidents Ids
            foreach (var incident in hero.Incidents)
            {
                var incidentFromDb = await _context.Incidents.FindAsync(incident.Id);
                if (incidentFromDb != null)
                {
                    hero.Incidents.Add(incidentFromDb);
                }
            }*/
            // add events to join table HeroEvent
           
            
            
            _context.Heroes.Add(hero);
            await _context.SaveChangesAsync();
            return hero;
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }
}

public interface IHeroService
{
    Task<Hero?> GetHeroAsync(int id, bool includeRelations = true);
    Task<IEnumerable<Hero>?> GetHeroesAsync();
    Task<Hero?> AddHeroAsync(Hero hero);
}