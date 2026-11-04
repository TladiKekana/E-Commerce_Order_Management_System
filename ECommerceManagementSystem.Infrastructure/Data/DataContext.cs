using ECommerceManagementSystem.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) {}

        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ProductSupplier> ProductSuppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Table Configurations

            // Configure Product table
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Product_Id);
                entity.Property(p => p.Name).IsRequired().HasMaxLength(150);
                entity.Property(p => p.Price).HasColumnType("decimal(18,2)");
            });
            // Configure Category table
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Category_Id);
                entity.Property(c => c.Name).IsRequired().HasMaxLength(150);
            });
            // Configure Supplier table
            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(s => s.Supplier_Id);
                entity.Property(s => s.Name).IsRequired().HasMaxLength(150);
            });
            // Configure OrderItem table
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(oi => oi.Order_Item_Id);
                entity.Property(oi => oi.Unit_Price).HasColumnType("decimal(18,2)");
            });
            // Configure Order table
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.Order_Id);
                entity.Property(o => o.Total_Amount).HasColumnType("decimal(18,2)");
            });
            // Configure Customer table
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(c => c.Customer_Id);
                entity.Property(c => c.First_Name).IsRequired().HasMaxLength(150);
                entity.Property(c => c.Last_Name).IsRequired().HasMaxLength(150);
            });
            // Configure ProductSupplier table
            modelBuilder.Entity<ProductSupplier>(entity =>
            {
                entity.HasKey(ps => ps.ProcuctSupplier_Id);
            });

            // Table Relationships configuration

            // Product(dependant entity) and Category(principal entity) one to many relationship
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.Category_Id)
                .OnDelete(DeleteBehavior.Cascade); // Automatically deletes products if category is deleted

            // Product(principal entity) and OrderItems(dependant entity) one to one relationship
            modelBuilder.Entity<Product>()
                .HasOne(p => p.OrderItem)
                .WithOne(oi => oi.Product)
                .HasForeignKey<OrderItem>(oi => oi.Product_Id)
                .OnDelete(DeleteBehavior.Cascade); // Automatically deletes OrderItem if Product is deleted

            // OrderItems(dependant entity) and Orders(principal entity) one to many relationship
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.Order_Id)
                .OnDelete(DeleteBehavior.Cascade); // Automatically deletes OrderItems if Order is deleted

            // Customer(principal entity) and Orders(dependant entity) one to many relationship
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.Customer_Id)
                .OnDelete(DeleteBehavior.Cascade); // Automatically deletes Orders if Customer is deleted

            // ProductSupplier many to many relationship
            modelBuilder.Entity<ProductSupplier>()
                .HasOne(ps => ps.Product)
                .WithMany(p => p.ProductSuppliers)
                .HasForeignKey(ps => ps.Product_Id)
                .OnDelete(DeleteBehavior.Cascade); // Automatically deletes ProductsSuppliers if Product is deleted
            modelBuilder.Entity<ProductSupplier>()
                .HasOne(ps => ps.Supplier)
                .WithMany(s => s.ProductSuppliers)
                .HasForeignKey(ps => ps.Supplier_Id)
                .OnDelete(DeleteBehavior.Cascade); // Automatically deletes ProductsSuppliers if Supplier is deleted
        }
    }
}
