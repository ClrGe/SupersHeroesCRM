namespace SupersHerosCRM.Models;

public class Incident
{
    public int Id { get; set; }
    public string Title { get; set; }
    public ICollection<Hero>? Heroes { get; set; }
    public ICollection<Event>? Events { get; set; }
}