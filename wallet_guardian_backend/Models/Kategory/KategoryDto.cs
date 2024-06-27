using System.ComponentModel.DataAnnotations;
using wallet_guardian_backend.Models.Subcategory;

namespace wallet_guardian_backend.Models.Kategory;

public class KategoryDto
{
    public int Id { get; set; }

    [Required] public string Name { get; set; }

    public long Icon { get; set; }

    public long Color { get; set; }

    public List<SubcategoryDto>? Subcategories { get; set; } = new List<SubcategoryDto>();
}