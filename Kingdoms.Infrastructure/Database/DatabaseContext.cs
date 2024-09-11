using Kingdoms.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kingdoms.Infrastructure.Database;

public class DatabaseContext : DbContext
{
    public DbSet<Player> Players { get; set; }
    public DbSet<Holding> Holdings { get; set; }

    private readonly string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KingdomsTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    public DatabaseContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(_connectionString);
}