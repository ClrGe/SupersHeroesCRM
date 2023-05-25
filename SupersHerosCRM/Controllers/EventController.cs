using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SupersHerosCRM.Models;
using SupersHerosCRM.Services;

namespace SupersHerosCRM.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEventAsync(int id)
    {
        var dbEvent = await _eventService.GetEventAsync(id);

        if (dbEvent == null) return StatusCode(StatusCodes.Status404NotFound, $"No Event found for id: {id}");
        Response.Headers.Add("Access-Control-Allow-Origin", "*");

        return StatusCode(StatusCodes.Status200OK, dbEvent);
    }

    [HttpGet]
    public async Task<IActionResult> GetEventsAsync()
    {
        var dbEvents = await _eventService.GetEventsAsync();

        if (dbEvents == null) return StatusCode(StatusCodes.Status404NotFound, "No events in database");
        Response.Headers.Add("Access-Control-Allow-Origin", "*");

        return StatusCode(StatusCodes.Status200OK, dbEvents);
    }

    [HttpPost("Add")]
    // accept all origin to prevent CORS error
    [EnableCors("AllowAll")]
    public async Task<ActionResult<Event>> AddEvent(Event eventToAdd)
    {
        var dbEvent = await _eventService.AddEventAsync(eventToAdd);

        if (dbEvent == null)
            return StatusCode(StatusCodes.Status404NotFound, $"{eventToAdd} could not be added.");

        return StatusCode(StatusCodes.Status201Created, dbEvent);
    }
}