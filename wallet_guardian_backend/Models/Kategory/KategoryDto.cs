using System.ComponentModel.DataAnnotations;
using wallet_guardian_backend.Models.Subcategory;

namespace wallet_guardian_backend.Models.Kategory;

public class KategoryDto
{
    public int Id { get; set; }

    [Required] public string Name { get; set; }

    public int Icon { get; set; }

    public int Color { get; set; }

    public virtual List<SubcategoryDto> Subcategories { get; set; }
}