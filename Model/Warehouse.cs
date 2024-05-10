using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalsAppHorizontal.Model;

public class Warehouse
{
    public int IdWarehouse { get; set; }
    [MaxLength(200)]
    public required string Name { get; set; }
    [MaxLength(200)]
    [Required]
    public required string Address { get; set; }
}