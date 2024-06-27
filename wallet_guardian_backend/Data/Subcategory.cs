using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wallet_guardian_backend.Data;

[Table("Subcategories", Schema = "WalletGuardianAPIDb")]
public class Subcategory
{
    public int Id { get; set; }

    [MaxLength(256)] [Required] public string Name { get; set; }

    public bool OnceAYear { get; set; }
}