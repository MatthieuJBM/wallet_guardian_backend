using Microsoft.EntityFrameworkCore;

namespace wallet_guardian_backend.Data;

public class WalletGuardianDbContext : DbContext
{
    public WalletGuardianDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Subcategory> Subcategories { get; set; }
    public DbSet<Kategory> Kategories { get; set; }
    public DbSet<Shop> Shops { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<MonthlyBudgetStatistic> MonthlyBudgetStatistics { get; set; }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     base.OnModelCreating(modelBuilder);
    //
    //     modelBuilder.Entity<Kategories>().HasData(
    //         new Kategory
    //         {
    //             
    //         }
    //         );
    // }
}