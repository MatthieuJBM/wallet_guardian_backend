using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wallet_guardian_backend.Data;

[Table("Kategories", Schema = "WalletGuardianAPIDb")]
public class Kategory
{
    public int Id { get; set; }

    [MaxLength(256)] [Required] public string Name { get; set; }

    public int Icon { get; set; }

    public int Color { get; set; }

    public virtual IList<Subcategory> Subcategories { get; set; }
}