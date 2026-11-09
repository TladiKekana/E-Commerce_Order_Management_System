using ECommerceManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) {}

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Inventory_Transaction> Inventory_Transactions { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Shipment> Shipments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Table Configurations

            // Configure Product table
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(a => a.Address_Id);
            });
            // Configure Inventory table
            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(i => i.Inventory_Id);
            });
            // Configure Inventory_Transaction table
            modelBuilder.Entity<Inventory_Transaction>(entity =>
            {
                entity.HasKey(it => it.Transaction_Id);
            });
            // Configure Payment table
            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(p => p.Payment_Id);
                entity.Property(p => p.Amount).HasColumnType("decimal(18,2)");
            });
            // Configure ProductImage table
            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.HasKey(pi => pi.Image_Id);
            });
            // Configure Role table
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(r => r.Role_Id);
                entity.Property(r => r.Name).IsRequired().HasMaxLength(150);
            });
            // Configure Shipments table
            modelBuilder.Entity<Shipment>(entity =>
            {
                entity.HasKey(s => s.Shipment_Id);
                entity.Property(s => s.Shipping_Cost).HasColumnType("decimal(18,2)");
            });
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
            // Configure User table
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.User_Id);
                entity.Property(u => u.First_Name).IsRequired().HasMaxLength(150);
                entity.Property(u => u.Last_Name).IsRequired().HasMaxLength(150);
            });

            // Table Relationships configuration

            // Product(dependant entity) and Category(principal entity) one to many relationship
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.Category_Id)
                .OnDelete(DeleteBehavior.Cascade); // Automatically deletes products if category is deleted

            // Product(dependant entity) and Supplier(principal entity) one to many relationship
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Supplier)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.Supplier_Id)
                .OnDelete(DeleteBehavior.Cascade); // Automatically deletes products if category is deleted

            // Product(principal entity) and ProductImage(dependant entity) one to many relationship
            modelBuilder.Entity<ProductImage>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.ProductImages)
                .HasForeignKey(pi => pi.Product_Id)
                .OnDelete(DeleteBehavior.Cascade); // Automatically deletes products if category is deleted

            // Product(principal entity) and Inventory(dependant entity) one to one relationship
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Inventory)
                .WithOne(i => i.Product)
                .HasForeignKey<Inventory>(i => i.Product_Id)
                .OnDelete(DeleteBehavior.Cascade); // Automatically deletes OrderItem if Product is deleted

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

            // User(principal entity) and Orders(dependant entity) one to many relationship
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.User_Id)
                .OnDelete(DeleteBehavior.NoAction); // Automatically deletes Orders if Customer is deleted

            // Payment(dependant entity) and Order(principal entity) one to many relationship
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Order)
                .WithMany(o => o.Payments)
                .HasForeignKey(p => p.Order_Id)
                .OnDelete(DeleteBehavior.Cascade); // Automatically deletes Orders if Customer is deleted

            // Shipment(dependant entity) and Order(principal entity) one to many relationship
            modelBuilder.Entity<Shipment>()
                .HasOne(s => s.Order)
                .WithMany(o => o.Shipments)
                .HasForeignKey(s => s.Order_Id)
                .OnDelete(DeleteBehavior.Cascade); // Automatically deletes Orders if Customer is deleted

            // Inventory_Transaction(dependant entity) and Inventory(principal entity) one to many relationship
            modelBuilder.Entity<Inventory_Transaction>()
                .HasOne(it => it.Inventory)
                .WithMany(i => i.Inventory_Transactions)
                .HasForeignKey(it => it.Inventory_Id)
                .OnDelete(DeleteBehavior.Cascade); // Automatically deletes Orders if Customer is deleted

            // Inventory_Transaction(dependant entity) and User(principal entity) one to many relationship
            modelBuilder.Entity<Inventory_Transaction>()
                .HasOne(it => it.User)
                .WithMany(u => u.Inventory_Transactions)
                .HasForeignKey(it => it.User_Id)
                .OnDelete(DeleteBehavior.Cascade); // Automatically deletes Orders if Customer is deleted

            // User(dependant entity) and Role(principal entity) one to many relationship
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.Role_Id)
                .OnDelete(DeleteBehavior.Cascade); // Automatically deletes Orders if Customer is deleted

            // Address(dependant entity) and User(principal entity) one to many relationship
            modelBuilder.Entity<Address>()
                .HasOne(a => a.User)
                .WithMany(u => u.Addresses)
                .HasForeignKey(a => a.User_Id)
                .OnDelete(DeleteBehavior.Cascade); // Automatically deletes Orders if Customer is deleted

            // Order(dependant entity) and Address(principal entity) one to many relationship
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Address)
                .WithMany(a => a.Orders)
                .HasForeignKey(o => o.Address_Id)
                .OnDelete(DeleteBehavior.Cascade); // Automatically deletes Orders if Customer is deleted
        }
    }
}
