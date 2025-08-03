using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FactoryManagement.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string PurchaseNumber { get; set; } = string.Empty;

        public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "decimal(10,2)")]
        public decimal Quantity { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalAmount { get; set; }

        [StringLength(20)]
        public string Status { get; set; } = "Pending"; // Pending, Received, Cancelled

        public DateTime? ReceivedDate { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Foreign keys
        public int SupplierId { get; set; }
        public int RawMaterialId { get; set; }

        // Navigation properties
        public virtual Supplier Supplier { get; set; } = null!;
        public virtual RawMaterial RawMaterial { get; set; } = null!;
    }
}