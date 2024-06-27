using wallet_guardian_backend.Contracts;
using wallet_guardian_backend.Data;

namespace wallet_guardian_backend.Repositories;

public class ShopsRepository : GenericRepository<Shop>, IShopsRepository
{
    public ShopsRepository(WalletGuardianDbContext context) : base(context)
    {
    }
}