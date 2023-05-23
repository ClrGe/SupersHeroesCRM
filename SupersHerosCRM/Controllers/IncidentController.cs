using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupersHerosCRM.Data;
using SupersHerosCRM.Models;
using SupersHerosCRM.Services;

namespace SupersHerosCRM.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IncidentController : ControllerBase
{
    private readonly IIncidentService _incidentService;
    
    public IncidentController(IIncidentService incidentService)
    {
        _incidentService = incidentService;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetIncidentAsync(int id)
    {
        var dbIncident = await _incidentService.GetIncidentAsync(id);
        
        if (dbIncident == null) return StatusCode(StatusCodes.Status404NotFound, $"No Incident found for id: {id}");
        Response.Headers.Add("Access-Control-Allow-Origin", "*");
        
        return StatusCode(StatusCodes.Status200OK, dbIncident);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetIncidentsAsync()
    {
        var dbIncidents = await _incidentService.GetIncidentsAsync();

        if (dbIncidents == null) return StatusCode(StatusCodes.Status404NotFound, "No incidents in database");
        Response.Headers.Add("Access-Control-Allow-Origin", "*");

        return StatusCode(StatusCodes.Status200OK, dbIncidents);
    }
    

}