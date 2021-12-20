﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata; // Comment
using ScaffoldingSample.Models;

namespace ScaffoldingSample.Contexts
{ // Comment
    public partial class NorthwindSlimContext : DbContext
    {
        // My Handlebars Helper
        public virtual DbSet<CategoryFoo> Categories { get; set; } = null!;
        // My Handlebars Helper
        public virtual DbSet<CustomerFoo> Customers { get; set; } = null!;
        // My Handlebars Helper
        public virtual DbSet<CustomerSettingFoo> CustomerSettings { get; set; } = null!;
        // My Handlebars Helper
        public virtual DbSet<EmployeeFoo> Employees { get; set; } = null!;
        // My Handlebars Helper
        public virtual DbSet<OrderFoo> Orders { get; set; } = null!;
        // My Handlebars Helper
        public virtual DbSet<OrderDetailFoo> OrderDetails { get; set; } = null!;
        // My Handlebars Helper
        public virtual DbSet<ProductFoo> Products { get; set; } = null!;
        // My Handlebars Helper
        public virtual DbSet<TerritoryFoo> Territories { get; set; } = null!;

        public NorthwindSlimContext()
        {
            
        }

        public NorthwindSlimContext(DbContextOptions<NorthwindSlimContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=NorthwindSlim; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerFoo>(entity =>
            {
                entity.Property(e => e.CustomerIdFoo).IsFixedLength();
            });

            modelBuilder.Entity<CustomerSettingFoo>(entity =>
            {
                entity.HasKey(e => e.CustomerIdFoo)
                    .HasName("PK_dbo.CustomerSetting");

                entity.Property(e => e.CustomerIdFoo).IsFixedLength();

                entity.HasOne(d => d.CustomerFoo)
                    .WithOne(p => p.CustomerSettingFoo)
                    .HasForeignKey<CustomerSettingFoo>(d => d.CustomerIdFoo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerSetting_Customer");
            });

            modelBuilder.Entity<EmployeeFoo>(entity =>
            {
                entity.HasMany(d => d.TerritoriesFoo)
                    .WithMany(p => p.EmployeesFoo)
                    .UsingEntity<Dictionary<string, object>>(
                        "EmployeeTerritory",
                        l => l.HasOne<TerritoryFoo>().WithMany().HasForeignKey("TerritoryId").HasConstraintName("FK_dbo.EmployeeTerritories_dbo.Territory_TerritoryId"),
                        r => r.HasOne<EmployeeFoo>().WithMany().HasForeignKey("EmployeeId").HasConstraintName("FK_dbo.EmployeeTerritories_dbo.Employee_EmployeeId"),
                        j =>
                        {
                            j.HasKey("EmployeeId", "TerritoryId").HasName("PK_dbo.EmployeeTerritories");

                            j.ToTable("EmployeeTerritories");

                            j.IndexerProperty<string>("TerritoryId").HasMaxLength(20);
                        });
            });

            modelBuilder.Entity<OrderFoo>(entity =>
            {
                entity.Property(e => e.CustomerIdFoo).IsFixedLength();

                entity.Property(e => e.FreightFoo).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.CustomerFoo)
                    .WithMany(p => p.OrdersFoo)
                    .HasForeignKey(d => d.CustomerIdFoo)
                    .HasConstraintName("FK_Orders_Customers");
            });

            modelBuilder.Entity<OrderDetailFoo>(entity =>
            {
                entity.Property(e => e.QuantityFoo).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.OrderFoo)
                    .WithMany(p => p.OrderDetailsFoo)
                    .HasForeignKey(d => d.OrderIdFoo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Details_Orders");

                entity.HasOne(d => d.ProductFoo)
                    .WithMany(p => p.OrderDetailsFoo)
                    .HasForeignKey(d => d.ProductIdFoo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Details_Products");
            });

            modelBuilder.Entity<ProductFoo>(entity =>
            {
                entity.Property(e => e.RowVersionFoo)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.UnitPriceFoo).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.CategoryFoo)
                    .WithMany(p => p.ProductsFoo)
                    .HasForeignKey(d => d.CategoryIdFoo)
                    .HasConstraintName("FK_Products_Categories");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
