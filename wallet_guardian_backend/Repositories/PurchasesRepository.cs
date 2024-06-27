using wallet_guardian_backend.Contracts;
using wallet_guardian_backend.Data;

namespace wallet_guardian_backend.Repositories;

public class PurchasesRepository : GenericRepository<Purchase>, IPurchasesRepository
{
    public PurchasesRepository(WalletGuardianDbContext context) : base(context)
    {
    }
}