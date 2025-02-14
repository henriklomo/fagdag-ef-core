using Bogus;
using Microsoft.EntityFrameworkCore;

namespace FagDag.EfCore.Database;

public class EpicEventsDbContext(DbContextOptions<EpicEventsDbContext> options) : DbContext(options)
{
    public DbSet<Event> Event { get; set; }
    public DbSet<Location> Location { get; set; }

    private static string DbPath { get => "EpicEvents.db"; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSeeding((context, _) =>
        {

            var fakerLocation = new Faker<Location>()
                .UseSeed(420)
                .RuleFor(x => x.Id, f => f.Random.Guid())
                .RuleFor(x => x.Name, f => f.Address.City())
                .RuleFor(x => x.Latitude, f => (long)f.Address.Latitude())
                .RuleFor(x => x.Longitude, f => (long)f.Address.Longitude());


            var locationToSeed = fakerLocation.Generate(5);
            var contains = context.Set<Location>().Contains(locationToSeed[0]);
            if (!contains)
            {
                context.Set<Location>().AddRange(locationToSeed);
                context.SaveChanges();
            }

            var fakerEvent = new Faker<Event>()
                .UseSeed(420)
                .RuleFor(x => x.Id, f => f.Random.Guid())
                .RuleFor(x => x.Name, f => f.Lorem.Text())
                .RuleFor(x => x.Description, f => f.Lorem.Sentence())
                .RuleFor(x => x.StartDate, f => f.Date.Future())
                .RuleFor(x => x.EndDate, f => f.Date.Future())
                .RuleFor(x => x.Location, f => f.PickRandom(locationToSeed))
                .RuleFor(x => x.MusicType, f => f.Lorem.Text());

            var eventsToSeed = fakerEvent.Generate(5);
            var containsEvents = context.Set<Event>().Contains(eventsToSeed[0]);
            if (!containsEvents)
            {
                context.Set<Event>().AddRange(eventsToSeed[0]);
                context.SaveChanges();
            }
        });
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
