using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata; // Comment
using dbo = ScaffoldingSample2.Models.dbo;

namespace ScaffoldingSample2.Contexts
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
            modelBuilder.Entity<dbo.CategoryFoo>(entity =>
            {
                entity.HasKey(e => e.CategoryIdFoo)
                    .HasName("PK_Categories");

                entity.ToTable("Category");

                entity.Property(e => e.CategoryIdFoo).HasColumnName("CategoryId");

                entity.Property(e => e.CategoryNameFoo)
                    .HasColumnName("CategoryName")
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<dbo.CustomerFoo>(entity =>
            {
                entity.HasKey(e => e.CustomerIdFoo)
                    .HasName("PK_Customers");

                entity.ToTable("Customer");

                entity.Property(e => e.CustomerIdFoo)
                    .HasColumnName("CustomerId")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.CityFoo)
                    .HasColumnName("City")
                    .HasMaxLength(15);

                entity.Property(e => e.CompanyNameFoo)
                    .HasColumnName("CompanyName")
                    .HasMaxLength(40);

                entity.Property(e => e.ContactNameFoo)
                    .HasColumnName("ContactName")
                    .HasMaxLength(30);

                entity.Property(e => e.CountryFoo)
                    .HasColumnName("Country")
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<dbo.CustomerSettingFoo>(entity =>
            {
                entity.HasKey(e => e.CustomerIdFoo)
                    .HasName("PK_dbo.CustomerSetting");

                entity.ToTable("CustomerSetting");

                entity.Property(e => e.CustomerIdFoo)
                    .HasColumnName("CustomerId")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.SettingFoo)
                    .HasColumnName("Setting")
                    .HasMaxLength(50);

                entity.HasOne(d => d.CustomerFoo)
                    .WithOne(p => p.CustomerSettingFoo)
                    .HasForeignKey<dbo.CustomerSettingFoo>(d => d.CustomerIdFoo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerSetting_Customer");
            });

            modelBuilder.Entity<dbo.EmployeeFoo>(entity =>
            {
                entity.HasKey(e => e.EmployeeIdFoo)
                    .HasName("PK_dbo.Employee");

                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeIdFoo).HasColumnName("EmployeeId");

                entity.Property(e => e.BirthDateFoo)
                    .HasColumnName("BirthDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.CityFoo)
                    .HasColumnName("City")
                    .HasMaxLength(15);

                entity.Property(e => e.CountryFoo)
                    .HasColumnName("Country")
                    .HasMaxLength(15);

                entity.Property(e => e.FirstNameFoo)
                    .HasColumnName("FirstName")
                    .HasMaxLength(20);

                entity.Property(e => e.HireDateFoo)
                    .HasColumnName("HireDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastNameFoo)
                    .HasColumnName("LastName")
                    .HasMaxLength(20);

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
                entity.HasKey(e => e.OrderIdFoo)
                    .HasName("PK_Orders");

                entity.ToTable("Order");

                entity.Property(e => e.OrderIdFoo).HasColumnName("OrderId");

                entity.Property(e => e.CustomerIdFoo)
                    .HasColumnName("CustomerId")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.FreightFoo)
                    .HasColumnName("Freight")
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderDateFoo)
                    .HasColumnName("OrderDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ShipViaFoo).HasColumnName("ShipVia");

                entity.Property(e => e.ShippedDateFoo)
                    .HasColumnName("ShippedDate")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.CustomerFoo)
                    .WithMany(p => p.OrdersFoo)
                    .HasForeignKey(d => d.CustomerIdFoo)
                    .HasConstraintName("FK_Orders_Customers");
            });

            modelBuilder.Entity<dbo.OrderDetailFoo>(entity =>
            {
                entity.HasKey(e => e.OrderDetailIdFoo)
                    .HasName("PK_OrderDetails");

                entity.ToTable("OrderDetail");

                entity.Property(e => e.OrderDetailIdFoo).HasColumnName("OrderDetailId");

                entity.Property(e => e.DiscountFoo).HasColumnName("Discount");

                entity.Property(e => e.OrderIdFoo).HasColumnName("OrderId");

                entity.Property(e => e.ProductIdFoo).HasColumnName("ProductId");

                entity.Property(e => e.QuantityFoo)
                    .HasColumnName("Quantity")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UnitPriceFoo)
                    .HasColumnName("UnitPrice")
                    .HasColumnType("money");

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
                entity.HasKey(e => e.ProductIdFoo)
                    .HasName("PK_Products");

                entity.ToTable("Product");

                entity.Property(e => e.ProductIdFoo).HasColumnName("ProductId");

                entity.Property(e => e.CategoryIdFoo).HasColumnName("CategoryId");

                entity.Property(e => e.DiscontinuedFoo).HasColumnName("Discontinued");

                entity.Property(e => e.ProductNameFoo)
                    .HasColumnName("ProductName")
                    .HasMaxLength(40);

                entity.Property(e => e.RowVersionFoo)
                    .HasColumnName("RowVersion")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.UnitPriceFoo)
                    .HasColumnName("UnitPrice")
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.CategoryFoo)
                    .WithMany(p => p.ProductsFoo)
                    .HasForeignKey(d => d.CategoryIdFoo)
                    .HasConstraintName("FK_Products_Categories");
            });

            modelBuilder.Entity<dbo.TerritoryFoo>(entity =>
            {
                entity.HasKey(e => e.TerritoryIdFoo)
                    .HasName("PK_dbo.Territory");

                entity.ToTable("Territory");

                entity.Property(e => e.TerritoryIdFoo)
                    .HasColumnName("TerritoryId")
                    .HasMaxLength(20);

                entity.Property(e => e.TerritoryDescriptionFoo)
                    .HasColumnName("TerritoryDescription")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
