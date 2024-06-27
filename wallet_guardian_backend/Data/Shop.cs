using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wallet_guardian_backend.Data;

[Table("Shops", Schema = "WalletGuardianAPIDb")]
public class Shop
{
    public int Id { get; set; }

    [MaxLength(256)] [Required] public string Name { get; set; }
}