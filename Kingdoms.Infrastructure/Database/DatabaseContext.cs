using Kingdoms.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Kingdoms.Infrastructure.Database;

public class DatabaseContext : DbContext
{
    public DbSet<Player> Players { get; set; }
    public DbSet<Holding> Holdings { get; set; }
    public DbSet<Building> Buildings { get; set; }
    public DbSet<Resources> Resources { get; set; }

    private readonly string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Kingdoms;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"; // Environment.GetEnvironmentVariable("SQL_CONNTECTION_STRING");

    public DatabaseContext()
    {
    }

    private void OnSavingChanges(object? sender, SavingChangesEventArgs e)
    {
        Log.Debug("OnSavingChanges()");
    }

    private void OnSavedChanges(object? sender, SavedChangesEventArgs e)
    {
        Log.Debug("OnSavedChanges()");
    }

    private void OnSaveChangesFailed(object? sender, SaveChangesFailedEventArgs e)
    {
        Log.Debug("OnSaveChangesFailed()");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(_connectionString);
}