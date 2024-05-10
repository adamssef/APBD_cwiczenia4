using System.ComponentModel.DataAnnotations;

namespace AnimalsAppHorizontal.Model;

public class Order
{
    public int IdOrder { get; set; }
    [Required]
    public int IdProduct { get; set; }
    [Required]
    public required int Amount { get; set; }
    [Required]
    public required DateTime CreatedAt { get; set; }
    public DateTime? FulfilledAt { get; set; }
}