using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalsAppHorizontal.Model;

public class Product
{
  
    public int IdProduct{ get; set; }
    [MaxLength(200)]
    public required string Name { get; set; }
    [MaxLength(200)]
    public string? Description { get; set; }
    [Required]
    [Column(TypeName = "decimal(25, 2)")]
    public required decimal Price { get; set; }
}