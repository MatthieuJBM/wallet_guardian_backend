using System.ComponentModel.DataAnnotations.Schema;

namespace wallet_guardian_backend.Data;

[Table("MonthlyBudgetStatistics", Schema = "WalletGuardianAPIDb")]
public class MonthlyBudgetStatistic
{
    public int Id { get; set; }

    public int Month { get; set; }

    public int Year { get; set; }

    public double Income { get; set; }

    public IList<Purchase> Purchases { get; set; }

    public double AdditionalIncomes { get; set; }

    public double CarOdometerReadingFirstDayOfMonth { get; set; }

    public double CarOdometerReadingLastDayOfMonth { get; set; }
}