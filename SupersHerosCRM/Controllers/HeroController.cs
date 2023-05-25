using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SupersHerosCRM.Models;
using SupersHerosCRM.Services;

namespace SupersHerosCRM.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HeroController : ControllerBase
{
    private readonly IHeroService _heroService;

    public HeroController(IHeroService heroService)
    {
        _heroService = heroService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetHeroAsync(int id)
    {
        var dbHero = await _heroService.GetHeroAsync(id);

        if (dbHero == null) return StatusCode(StatusCodes.Status404NotFound, $"No Hero found for id: {id}");
        Response.Headers.Add("Access-Control-Allow-Origin", "*");

        return StatusCode(StatusCodes.Status200OK, dbHero);
    }

    [HttpGet]
    public async Task<IActionResult> GetHeroesAsync()
    {
        var dbHeroes = await _heroService.GetHeroesAsync();

        if (dbHeroes == null) return StatusCode(StatusCodes.Status404NotFound, "No heroes in database");
        Response.Headers.Add("Access-Control-Allow-Origin", "*");

        return StatusCode(StatusCodes.Status200OK, dbHeroes);
    }


    [HttpPost("Add")]
    // accept all origin to prevent CORS error
    [EnableCors("AllowAll")]
    public async Task<ActionResult<Hero>> AddHero(Hero hero)
    {
        var dbHero = await _heroService.AddHeroAsync(hero);

        if (dbHero == null)
            return StatusCode(StatusCodes.Status404NotFound, $"{hero.Name} could not be added.");

        return StatusCode(StatusCodes.Status201Created, dbHero);
    }
}