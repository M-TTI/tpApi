using Microsoft.EntityFrameworkCore;
using tpApi.Controllers;
using tpApi.Models;

namespace tpApi.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Forecast> Forecasts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Forecast>()
            .Property(f => f.City)
            .HasConversion<string>();
        
        modelBuilder.Entity<Forecast>()
            .Property(f => f.Condition)
            .HasConversion<string>();
    }
}