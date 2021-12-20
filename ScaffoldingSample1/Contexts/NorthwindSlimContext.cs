using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata; // Comment
using dbo = ScaffoldingSample.Models.dbo;

namespace ScaffoldingSample.Contexts
{ // Comment
    public partial class NorthwindSlimContext : DbContext
    {
        // My Handlebars Helper
        public virtual DbSet<dbo.CategoryFoo> Categories { get; set; } = null!;
        // My Handlebars Helper
        public virtual DbSet<dbo.CustomerFoo> Customers { get; set; } = null!;
        // My Handlebars Helper
        public virtual DbSet<dbo.CustomerSettingFoo> CustomerSettings { get; set; } = null!;
        // My Handlebars Helper
        public virtual DbSet<dbo.EmployeeFoo> Employees { get; set; } = null!;
        // My Handlebars Helper
        public virtual DbSet<dbo.OrderFoo> Orders { get; set; } = null!;
        // My Handlebars Helper
        public virtual DbSet<dbo.OrderDetailFoo> OrderDetails { get; set; } = null!;
        // My Handlebars Helper
        public virtual DbSet<dbo.ProductFoo> Products { get; set; } = null!;
        // My Handlebars Helper
        public virtual DbSet<dbo.TerritoryFoo> Territories { get; set; } = null!;

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
            modelBuilder.Entity<dbo.CustomerFoo>(entity =>
            {
                entity.Property(e => e.CustomerIdFoo).IsFixedLength();
            });

            modelBuilder.Entity<dbo.CustomerSettingFoo>(entity =>
            {
                entity.HasKey(e => e.CustomerIdFoo)
                    .HasName("PK_dbo.CustomerSetting");

                entity.Property(e => e.CustomerIdFoo).IsFixedLength();

                entity.HasOne(d => d.CustomerFoo)
                    .WithOne(p => p.CustomerSettingFoo)
                    .HasForeignKey<dbo.CustomerSettingFoo>(d => d.CustomerIdFoo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerSetting_Customer");
            });

            modelBuilder.Entity<dbo.EmployeeFoo>(entity =>
            {
                entity.HasMany(d => d.TerritoriesFoo)
                    .WithMany(p => p.EmployeesFoo)
                    .UsingEntity<Dictionary<string, object>>(
                        "EmployeeTerritory",
                        l => l.HasOne<dbo.TerritoryFoo>().WithMany().HasForeignKey("TerritoryId").HasConstraintName("FK_dbo.EmployeeTerritories_dbo.Territory_TerritoryId"),
                        r => r.HasOne<dbo.EmployeeFoo>().WithMany().HasForeignKey("EmployeeId").HasConstraintName("FK_dbo.EmployeeTerritories_dbo.Employee_EmployeeId"),
                        j =>
                        {
                            j.HasKey("EmployeeId", "TerritoryId").HasName("PK_dbo.EmployeeTerritories");

                            j.ToTable("EmployeeTerritories");

                            j.IndexerProperty<string>("TerritoryId").HasMaxLength(20);
                        });
            });

            modelBuilder.Entity<dbo.OrderFoo>(entity =>
            {
                entity.Property(e => e.CustomerIdFoo).IsFixedLength();

                entity.Property(e => e.FreightFoo).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.CustomerFoo)
                    .WithMany(p => p.OrdersFoo)
                    .HasForeignKey(d => d.CustomerIdFoo)
                    .HasConstraintName("FK_Orders_Customers");
            });

            modelBuilder.Entity<dbo.OrderDetailFoo>(entity =>
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

            modelBuilder.Entity<dbo.ProductFoo>(entity =>
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
