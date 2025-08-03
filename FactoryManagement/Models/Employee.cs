using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FactoryManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [StringLength(150)]
        public string? Email { get; set; }

        [StringLength(20)]
        public string? Phone { get; set; }

        [StringLength(100)]
        public string? Position { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? Salary { get; set; }

        public DateTime HireDate { get; set; } = DateTime.UtcNow;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Foreign key
        public int DepartmentId { get; set; }

        // Navigation properties
        public virtual Department Department { get; set; } = null!;
        public virtual ICollection<Production> Productions { get; set; } = new List<Production>();
    }
}