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
            entity.HasMany(e => e.Incidents).WithMany(e => e.Heroes);
        });

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
            entity.HasOne(e => e.Incident);
            entity.Property(e => e.IncidentId);
            // location
            entity.Property(e => e.City);
            entity.Property(e => e.Longitude).IsRequired();
            entity.Property(e => e.Latitude).IsRequired();
            entity.Property(e => e.Status).HasDefaultValue("pending");
            // hero 
            entity.Property(e => e.HeroId);
            entity.Property(t => t.CreatedAt).HasPrecision(0).ValueGeneratedOnAdd().HasDefaultValueSql("NOW()");


            // add date in the Currents table
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
        
            
        // result is true if the database had to be created
    }
}