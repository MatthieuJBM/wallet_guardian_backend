using wallet_guardian_backend.Contracts;
using wallet_guardian_backend.Data;

namespace wallet_guardian_backend.Repositories;

public class KategoriesRepository : GenericRepository<Kategory>, IKategoriesRepository
{
    public KategoriesRepository(WalletGuardianDbContext context) : base(context)
    {
    }
}