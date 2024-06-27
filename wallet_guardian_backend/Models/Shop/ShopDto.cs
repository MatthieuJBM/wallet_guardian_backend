using System.ComponentModel.DataAnnotations;

namespace wallet_guardian_backend.Models.Shop;

public class ShopDto
{
    public int Id { get; set; }
    
    [Required] public string Name { get; set; }
}