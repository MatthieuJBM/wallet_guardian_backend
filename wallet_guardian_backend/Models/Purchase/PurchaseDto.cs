using wallet_guardian_backend.Models.Kategory;
using wallet_guardian_backend.Models.Shop;
using wallet_guardian_backend.Models.Subcategory;

namespace wallet_guardian_backend.Models.Purchase;

public class PurchaseDto
{
    public int Id { get; set; }

    //public int ShopId { get; set; }
    public ShopDto Shop { get; set; }

    public double BillCost { get; set; }

    // public int CategoryId { get; set; }
    public KategoryDto Category { get; set; }

    // public int SubcategoryId { get; set; }
    public SubcategoryDto Subcategory { get; set; }

    public DateTime date { get; set; }

    public string Note { get; set; }
}