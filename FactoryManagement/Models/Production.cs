using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FactoryManagement.Models
{
    public class Production
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductionNumber { get; set; } = string.Empty;

        public DateTime ProductionDate { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "decimal(10,2)")]
        public decimal QuantityProduced { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? PlannedQuantity { get; set; }

        [StringLength(20)]
        public string Status { get; set; } = "Planned"; // Planned, InProgress, Completed, Cancelled

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Foreign keys
        public int ProductId { get; set; }
        public int? EmployeeId { get; set; } // Supervisor/Responsible employee

        // Navigation properties
        public virtual Product Product { get; set; } = null!;
        public virtual Employee? Employee { get; set; }
        public virtual ICollection<ProductionRawMaterial> ProductionRawMaterials { get; set; } = new List<ProductionRawMaterial>();
    }
}