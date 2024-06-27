using wallet_guardian_backend.Contracts;
using wallet_guardian_backend.Data;

namespace wallet_guardian_backend.Repositories;

public class MonthlyBudgetStatisticsRepository : GenericRepository<MonthlyBudgetStatistic>,
    IMonthlyBudgetStatisticsRepository
{
    public MonthlyBudgetStatisticsRepository(WalletGuardianDbContext context) : base(context)
    {
    }
}