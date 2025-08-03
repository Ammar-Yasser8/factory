# Factory Management System - Database Structure

This project implements a comprehensive database structure for a factory management system using Entity Framework Core.

## Entities Overview

The system includes the following main entities with their relationships:

### Core Entities

1. **Category**
   - Basic categorization for products
   - One-to-many relationship with Products

2. **Product**
   - Main product information with inventory tracking
   - Belongs to a Category
   - Related to Productions and Orders

3. **RawMaterial**
   - Materials used in production
   - Has inventory tracking and supplier relationships
   - Many-to-many relationship with Production through ProductionRawMaterial

4. **Supplier**
   - Supplier information and contact details
   - One-to-many relationship with Purchases

5. **Purchase**
   - Purchase orders for raw materials from suppliers
   - Links Suppliers and RawMaterials

### Organizational Entities

6. **Department**
   - Organizational departments
   - One-to-many relationship with Employees

7. **Employee**
   - Employee information
   - Belongs to a Department
   - Can supervise Productions

### Production Entities

8. **Production**
   - Production runs/batches
   - Links Products, Employees, and RawMaterials
   - Many-to-many relationship with RawMaterials through ProductionRawMaterial

9. **ProductionRawMaterial**
   - Junction table for Production and RawMaterial relationship
   - Tracks quantities used in production

### Sales Entities

10. **Customer**
    - Customer information and contact details
    - One-to-many relationship with Orders

11. **Order**
    - Customer orders
    - Links Customers and Products through OrderItems

12. **OrderItem**
    - Individual items within an order
    - Junction table for Order and Product relationship

## Key Features

- **Data Annotations**: Proper validation and constraints
- **Navigation Properties**: Complete relationship mapping
- **Fluent API Configuration**: Advanced relationship configuration
- **Indexing**: Unique constraints and performance optimization
- **Decimal Precision**: Proper handling of monetary and quantity values
- **Soft Delete Support**: Status-based record management
- **Audit Fields**: Created timestamps for tracking

## Database Configuration

The system uses SQL Server with the following connection string format:
```
Server=(localdb)\\mssqllocaldb;Database=FactoryManagementDb;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=true
```

## Getting Started

1. **Prerequisites**
   - .NET 8.0 SDK
   - SQL Server or SQL Server LocalDB
   - Entity Framework Core Tools

2. **Setup Database**
   ```bash
   dotnet ef database update
   ```

3. **Run Application**
   ```bash
   dotnet run
   ```

## Migration Information

- Initial migration: `InitialCreate`
- Creates all tables with proper relationships and constraints
- Includes indexes for performance optimization

## API Endpoints

The project includes a sample Categories controller demonstrating basic CRUD operations:
- GET /api/categories - List all categories
- GET /api/categories/{id} - Get specific category
- POST /api/categories - Create new category

## Entity Relationships Summary

```
Category (1) ←→ (Many) Product
Department (1) ←→ (Many) Employee
Supplier (1) ←→ (Many) Purchase
Customer (1) ←→ (Many) Order
RawMaterial (1) ←→ (Many) Purchase
Product (1) ←→ (Many) Production
Employee (1) ←→ (Many) Production
Order (1) ←→ (Many) OrderItem
Product (1) ←→ (Many) OrderItem
Production (Many) ←→ (Many) RawMaterial (via ProductionRawMaterial)
```

This structure provides a solid foundation for a comprehensive factory management system with proper data integrity and relationships.