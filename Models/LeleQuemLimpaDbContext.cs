using Microsoft.EntityFrameworkCore;

namespace LeleQuemLimpa.Models;

public class LeleQuemLimpaDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Day> Days => Set<Day>();
    public DbSet<Diva> Divas => Set<Diva>();

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Day>();

        model.Entity<Diva>()
            .HasMany(d => d.Days)
            .WithMany(d => d.Divas)
            .UsingEntity(j => j.ToTable("DayDiva"));
    }
}