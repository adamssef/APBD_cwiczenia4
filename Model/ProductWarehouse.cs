using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalsAppHorizontal.Model;

public class ProductWarehouse {
    [Key] // Indicates that this is the primary key
    [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdProductWarehouse { get; set; }

    [Required]
    public int IdProduct { get; set; }

    [Required]
    public int IdWarehouse { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
    public int Amount { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    public double Price { get; set; }

    public int IdOrder { get; set; } // This is used to link back to the Order table
}
