using Microsoft.EntityFrameworkCore;
using FactoryManagement.Models;

namespace FactoryManagement.Data
{
    public class FactoryDbContext : DbContext
    {
        public FactoryDbContext(DbContextOptions<FactoryDbContext> options) : base(options)
        {
        }

        // DbSets
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<RawMaterial> RawMaterials { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Production> Productions { get; set; }
        public DbSet<ProductionRawMaterial> ProductionRawMaterials { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Category
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.HasIndex(e => e.Name).IsUnique();
            });

            // Configure Department
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.Location).HasMaxLength(100);
                entity.HasIndex(e => e.Name).IsUnique();
            });

            // Configure Employee
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).HasMaxLength(150);
                entity.Property(e => e.Phone).HasMaxLength(20);
                entity.Property(e => e.Position).HasMaxLength(100);
                entity.Property(e => e.Salary).HasColumnType("decimal(10,2)");

                entity.HasOne(e => e.Department)
                    .WithMany(d => d.Employees)
                    .HasForeignKey(e => e.DepartmentId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(e => e.Email).IsUnique();
            });

            // Configure Supplier
            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(150);
                entity.Property(e => e.ContactPerson).HasMaxLength(100);
                entity.Property(e => e.Email).HasMaxLength(150);
                entity.Property(e => e.Phone).HasMaxLength(20);
                entity.Property(e => e.Address).HasMaxLength(200);
                entity.Property(e => e.City).HasMaxLength(100);
                entity.Property(e => e.Country).HasMaxLength(100);
                entity.Property(e => e.PostalCode).HasMaxLength(20);

                entity.HasIndex(e => e.Name).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
            });

            // Configure Customer
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(150);
                entity.Property(e => e.ContactPerson).HasMaxLength(100);
                entity.Property(e => e.Email).HasMaxLength(150);
                entity.Property(e => e.Phone).HasMaxLength(20);
                entity.Property(e => e.Address).HasMaxLength(200);
                entity.Property(e => e.City).HasMaxLength(100);
                entity.Property(e => e.Country).HasMaxLength(100);
                entity.Property(e => e.PostalCode).HasMaxLength(20);

                entity.HasIndex(e => e.Email).IsUnique();
            });

            // Configure RawMaterial
            modelBuilder.Entity<RawMaterial>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.Unit).HasMaxLength(20);
                entity.Property(e => e.CurrentStock).HasColumnType("decimal(10,2)");
                entity.Property(e => e.MinimumStock).HasColumnType("decimal(10,2)");
                entity.Property(e => e.UnitCost).HasColumnType("decimal(10,2)");

                entity.HasIndex(e => e.Name).IsUnique();
            });

            // Configure Product
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.SKU).HasMaxLength(50);
                entity.Property(e => e.Price).HasColumnType("decimal(10,2)");
                entity.Property(e => e.CurrentStock).HasColumnType("decimal(10,2)");
                entity.Property(e => e.MinimumStock).HasColumnType("decimal(10,2)");
                entity.Property(e => e.Unit).HasMaxLength(20);

                entity.HasOne(p => p.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(p => p.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(e => e.SKU).IsUnique();
                entity.HasIndex(e => e.Name).IsUnique();
            });

            // Configure Purchase
            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.PurchaseNumber).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Quantity).HasColumnType("decimal(10,2)");
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(10,2)");
                entity.Property(e => e.TotalAmount).HasColumnType("decimal(10,2)");
                entity.Property(e => e.Status).HasMaxLength(20);
                entity.Property(e => e.Notes).HasMaxLength(500);

                entity.HasOne(p => p.Supplier)
                    .WithMany(s => s.Purchases)
                    .HasForeignKey(p => p.SupplierId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.RawMaterial)
                    .WithMany(rm => rm.Purchases)
                    .HasForeignKey(p => p.RawMaterialId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(e => e.PurchaseNumber).IsUnique();
            });

            // Configure Order
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.OrderNumber).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Status).HasMaxLength(20);
                entity.Property(e => e.TotalAmount).HasColumnType("decimal(12,2)");
                entity.Property(e => e.Notes).HasMaxLength(500);

                entity.HasOne(o => o.Customer)
                    .WithMany(c => c.Orders)
                    .HasForeignKey(o => o.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(e => e.OrderNumber).IsUnique();
            });

            // Configure OrderItem
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Quantity).HasColumnType("decimal(10,2)");
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(10,2)");
                entity.Property(e => e.TotalPrice).HasColumnType("decimal(12,2)");

                entity.HasOne(oi => oi.Order)
                    .WithMany(o => o.OrderItems)
                    .HasForeignKey(oi => oi.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(oi => oi.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(oi => oi.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure Production
            modelBuilder.Entity<Production>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ProductionNumber).IsRequired().HasMaxLength(50);
                entity.Property(e => e.QuantityProduced).HasColumnType("decimal(10,2)");
                entity.Property(e => e.PlannedQuantity).HasColumnType("decimal(10,2)");
                entity.Property(e => e.Status).HasMaxLength(20);
                entity.Property(e => e.Notes).HasMaxLength(500);

                entity.HasOne(p => p.Product)
                    .WithMany(pr => pr.Productions)
                    .HasForeignKey(p => p.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.Employee)
                    .WithMany(e => e.Productions)
                    .HasForeignKey(p => p.EmployeeId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasIndex(e => e.ProductionNumber).IsUnique();
            });

            // Configure ProductionRawMaterial (Many-to-Many junction table)
            modelBuilder.Entity<ProductionRawMaterial>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.QuantityUsed).HasColumnType("decimal(10,2)");
                entity.Property(e => e.PlannedQuantity).HasColumnType("decimal(10,2)");
                entity.Property(e => e.Notes).HasMaxLength(500);

                entity.HasOne(prm => prm.Production)
                    .WithMany(p => p.ProductionRawMaterials)
                    .HasForeignKey(prm => prm.ProductionId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(prm => prm.RawMaterial)
                    .WithMany(rm => rm.ProductionRawMaterials)
                    .HasForeignKey(prm => prm.RawMaterialId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Ensure a production can't use the same raw material twice
                entity.HasIndex(e => new { e.ProductionId, e.RawMaterialId }).IsUnique();
            });
        }
    }
}