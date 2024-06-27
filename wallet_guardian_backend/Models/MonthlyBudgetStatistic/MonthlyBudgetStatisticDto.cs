using wallet_guardian_backend.Models.Purchase;

namespace wallet_guardian_backend.Models.MonthlyBudgetStatistic;

public class MonthlyBudgetStatisticDto
{
    public int Id { get; set; }

    public int Month { get; set; }

    public int Year { get; set; }

    public double Income { get; set; }

    public List<PurchaseDto> Purchases { get; set; }

    public double AdditionalIncomes { get; set; }

    public double CarOdometerReadingFirstDayOfMonth { get; set; }

    public double CarOdometerReadingLastDayOfMonth { get; set; }
}