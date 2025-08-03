using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FactoryManagement.Models
{
    /// <summary>
    /// Junction table for the many-to-many relationship between Production and RawMaterial
    /// </summary>
    public class ProductionRawMaterial
    {
        public int Id { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal QuantityUsed { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? PlannedQuantity { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }

        // Foreign keys
        public int ProductionId { get; set; }
        public int RawMaterialId { get; set; }

        // Navigation properties
        public virtual Production Production { get; set; } = null!;
        public virtual RawMaterial RawMaterial { get; set; } = null!;
    }
}