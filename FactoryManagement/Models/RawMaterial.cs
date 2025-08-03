using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FactoryManagement.Models
{
    public class RawMaterial
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        [StringLength(20)]
        public string? Unit { get; set; } // kg, liter, piece, etc.

        [Column(TypeName = "decimal(10,2)")]
        public decimal CurrentStock { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal MinimumStock { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? UnitCost { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
        public virtual ICollection<ProductionRawMaterial> ProductionRawMaterials { get; set; } = new List<ProductionRawMaterial>();
    }
}