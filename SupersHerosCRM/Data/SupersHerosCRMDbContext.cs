using Microsoft.EntityFrameworkCore;
using SupersHerosCRM.Models;

namespace SupersHerosCRM.Data;

public class SupersHerosCRMDbContext : DbContext
{
    // create the database 
    public SupersHerosCRMDbContext()
    {
        Database.EnsureCreated();
    }

    public SupersHerosCRMDbContext(DbContextOptions<SupersHerosCRMDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Hero> Heroes { get; set; }

    public virtual DbSet<Incident> Incidents { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hero>(entity =>
        {
            entity.ToTable("Heroes");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.HasIndex(e => e.Id);
            entity.Property(e => e.IncidentId);
            entity.HasMany(e => e.Incidents)
                .WithMany(e => e.Heroes)
                .UsingEntity<Dictionary<string, object>>(
                    "HeroIncident",
                    j => j
                        .HasOne<Incident>()
                        .WithMany()
                        .HasForeignKey("IncidentId"),
                    j => j
                        .HasOne<Hero>()
                        .WithMany()
                        .HasForeignKey("HeroId"));
            entity.HasMany(e => e.Events)
                .WithMany(e => e.Heroes)
                .UsingEntity<Dictionary<string, object>>(
                    "HeroEvent",
                    j => j
                        .HasOne<Event>()
                        .WithMany()
                        .HasForeignKey("EventId"),
                    j => j
                        .HasOne<Hero>()
                        .WithMany()
                        .HasForeignKey("HeroId"));
            modelBuilder.Entity<Incident>(entity =>
            {
                entity.ToTable("Incidents");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired();
                // add values in the incidents table
                entity.HasData(new Incident { Id = 1, Title = "Incendie" });
                entity.HasData(new Incident { Id = 2, Title = "Accident routier" });
                entity.HasData(new Incident { Id = 3, Title = "Accident fluvial" });
                entity.HasData(new Incident { Id = 4, Title = "Accident aérien" });
                entity.HasData(new Incident { Id = 5, Title = "Eboulement" });
                entity.HasData(new Incident { Id = 6, Title = "Invasion de serpents" });
                entity.HasData(new Incident { Id = 7, Title = "Fuite de gaz" });
                entity.HasData(new Incident { Id = 8, Title = "Manifestation" });
                entity.HasData(new Incident { Id = 9, Title = "Braquage" });
                entity.HasData(new Incident { Id = 10, Title = "Evasion d’un prisonnier" });
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Events");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasIndex(e => e.Id);

                // incidentId is a foreign key
                entity.Property(e => e.IncidentId);
                entity.HasMany(e => e.Incidents)
                    .WithMany(e => e.Events)
                    .UsingEntity<Dictionary<string, object>>(
                        "EventIncident",
                        j => j
                            .HasOne<Incident>()
                            .WithMany()
                            .HasForeignKey("IncidentId"),
                        j => j
                            .HasOne<Event>()
                            .WithMany()
                            .HasForeignKey("EventId"));

                entity.Property(e => e.City);
                entity.Property(e => e.Longitude).IsRequired();
                entity.Property(e => e.Latitude).IsRequired();
                entity.Property(e => e.Status).HasDefaultValue("pending");
                // hero 
                entity.Property(e => e.HeroId);
                entity.Property(t => t.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValueSql("NOW()");
            });
        });
    }

    public static async Task EnsureDbCreatedAndSeedWithCountOfAsync(DbContextOptions<SupersHerosCRMDbContext> options,
        int count)
    {
        var factory = new LoggerFactory();
        var builder = new DbContextOptionsBuilder<SupersHerosCRMDbContext>(options)
            .UseLoggerFactory(factory);


        await using var context = new SupersHerosCRMDbContext(builder.Options);
        var created = await context.Database.EnsureCreatedAsync();
    }
}