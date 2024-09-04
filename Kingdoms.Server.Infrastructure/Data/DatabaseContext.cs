using Kingdoms.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kingdoms.Server.Infrastructure.Data;

public class DatabaseContext : DbContext
{
    private readonly string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KingdomsTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    public DbSet<Player> Players { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlServer(_connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>()
            .HasOne(p => p.Inventory)
            .WithOne(i => i.Player)
            .HasForeignKey<Inventory>(i => i.PlayerId);

        modelBuilder.Entity<InventoryItem>()
            .HasKey(ii => new { ii.InventoryId, ii.ItemId }); // Composite primary key

        modelBuilder.Entity<InventoryItem>()
            .HasOne(ii => ii.Inventory)
            .WithMany(i => i.Items)
            .HasForeignKey(ii => ii.InventoryId);

        modelBuilder.Entity<InventoryItem>()
            .HasOne(ii => ii.Item)
            .WithMany() // An item can be in many inventories
            .HasForeignKey(ii => ii.ItemId);

        base.OnModelCreating(modelBuilder);
    }
}