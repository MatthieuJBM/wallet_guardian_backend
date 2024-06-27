using Microsoft.EntityFrameworkCore;

namespace wallet_guardian_backend.Data;

public class WalletGuardianDbContext : DbContext
{
    public WalletGuardianDbContext(DbContextOptions options) : base(options)
    {
    }
}