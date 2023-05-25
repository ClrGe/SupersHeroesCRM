using System.ComponentModel.DataAnnotations;

namespace SupersHerosCRM.Models;

public class Hero
{
    public int Id { get; set; }

    [Required] public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public double? Longitude { get; set; }

    public double? Latitude { get; set; }

    [MaxLength(3)]
    public int[]? IncidentId { get; set; }

    public ICollection<Incident>? Incidents { get; set; }
    public ICollection<Event>? Events { get; set; }
}