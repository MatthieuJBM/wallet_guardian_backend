using wallet_guardian_backend.Contracts;
using wallet_guardian_backend.Data;

namespace wallet_guardian_backend.Repositories;

public class SubcategoriesRepository : GenericRepository<Subcategory>, ISubcategoriesRepository
{
    public SubcategoriesRepository(WalletGuardianDbContext context) : base(context)
    {
    }
}