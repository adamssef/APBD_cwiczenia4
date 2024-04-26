using System.ComponentModel.DataAnnotations;

namespace AnimalsAppHorizontal.Model;

public class Animal
{
    public int idAnimal { get; set; }
    [MaxLength(200)]
    public required string Name { get; set; }
    [MaxLength(200)]
    public string? Description { get; set; }
    [Required]
    [MaxLength(200)]
    public required string Category { get; set; }
    [Required]
    [MaxLength(200)]
    public required string Area { get; set; }
}