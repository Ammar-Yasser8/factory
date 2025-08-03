# Factory Management System

A comprehensive factory management system built with ASP.NET Core and Entity Framework Core.

## Project Structure

- **FactoryManagement/** - Main ASP.NET Core Web API project
  - Complete database structure with Entity Framework Core
  - 12 entity models covering all aspects of factory management
  - RESTful API endpoints
  - Comprehensive relationship mapping

## Features

- **Product Management**: Categories, products, inventory tracking
- **Raw Material Management**: Material tracking, supplier relationships
- **Production Management**: Production runs, resource allocation
- **Human Resources**: Departments, employees, role assignments
- **Supply Chain**: Suppliers, purchases, procurement tracking
- **Sales & Orders**: Customer management, order processing
- **Reporting Ready**: Structured data for analytics and reporting

## Technology Stack

- **Backend**: ASP.NET Core 8.0 Web API
- **Database**: Entity Framework Core with SQL Server
- **Documentation**: Swagger/OpenAPI integration

## Quick Start

```bash
cd FactoryManagement
dotnet restore
dotnet ef database update
dotnet run
```

For detailed setup instructions and entity documentation, see [FactoryManagement/README.md](FactoryManagement/README.md).

## Database Schema

The system includes 12 interconnected entities:
- Category, Product, RawMaterial
- Supplier, Purchase, Production
- Employee, Department, Order
- Customer, OrderItem, ProductionRawMaterial

Complete with proper relationships, constraints, and indexing for optimal performance.