namespace SupersHerosCRM.Models;

public class Event
{
    public int Id { get; set; }
    public string? City { get; set; }
    public double? Longitude { get; set; }

    public double? Latitude { get; set; }
    public int IncidentId { get; set; }
    public Incident? Incident { get; set; }
    
    public int? HeroId { get; set; }
    public Hero? Hero { get; set; }

    public string Status { get; set; }
    public DateTime? CreatedAt { get; set; }
}