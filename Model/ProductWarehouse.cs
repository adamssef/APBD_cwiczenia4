using System;
using System.ComponentModel.DataAnnotations;

namespace AnimalsAppHorizontal.Model;

public class ProductWarehouse
{
    [Required]
    public int IdProduct { get; set; }

    [Required]
    public int IdWarehouse { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
    public int Amount { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    // This may be needed if you implement price calculations or validations
    public double Price { get; set; }

    // If you handle orders directly, you might need an order ID field
    public int IdOrder { get; set; }
}