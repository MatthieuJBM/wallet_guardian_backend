using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wallet_guardian_backend.Data;

[Table("Purchases", Schema = "WalletGuardianAPIDb")]
public class Purchase
{
    public int Id { get; set; }

    public Shop Shop { get; set; }

    [Required] public double BillCost { get; set; }

    public Kategory Category { get; set; }

    public Subcategory Subcategory { get; set; }

    public DateTime date { get; set; }

    public string Note { get; set; }
}