using System.ComponentModel.DataAnnotations;

namespace wallet_guardian_backend.Models.Subcategory;

public class SubcategoryDto
{
    public int Id { get; set; }

    [Required] public string Name { get; set; }

    public bool OnceAYear { get; set; }
}