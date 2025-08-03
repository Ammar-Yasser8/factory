using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FactoryManagement.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        [StringLength(50)]
        public string? SKU { get; set; } // Stock Keeping Unit

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal CurrentStock { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal MinimumStock { get; set; }

        [StringLength(20)]
        public string? Unit { get; set; } // piece, kg, liter, etc.

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Foreign key
        public int CategoryId { get; set; }

        // Navigation properties
        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<Production> Productions { get; set; } = new List<Production>();
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}