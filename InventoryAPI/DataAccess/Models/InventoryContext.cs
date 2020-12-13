using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace modelscaffold.Model
{
    public partial class InventoryContext : DbContext
    {
        public InventoryContext()
        {
        }

        public InventoryContext(DbContextOptions<InventoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Collection> Collections { get; set; }
        public virtual DbSet<CurrentInventory> CurrentInventories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductComment> ProductComments { get; set; }
        public virtual DbSet<ProductDescription> ProductDescriptions { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }
        public virtual DbSet<WarehouseClerk> WarehouseClerks { get; set; }
        public virtual DbSet<WarehouseManager> WarehouseManagers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server = localhost; Database = Inventory; User Id = SA; Password = kingMAKER0116@;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Collection>(entity =>
            {
                entity.ToTable("collections");

                entity.Property(e => e.CollectionId).HasColumnName("CollectionID");

                entity.Property(e => e.CollectionDesc)
                    .HasColumnType("text")
                    .HasDefaultValueSql("('NA')");

                entity.Property(e => e.CollectionName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CurrentInventory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("currentInventory");

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SKU")
                    .IsFixedLength(true);

                entity.Property(e => e.Stock)
                    .HasColumnName("stock")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.WarehouseId).HasColumnName("WarehouseID");

                entity.HasOne(d => d.SkuNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Sku)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product");

                entity.HasOne(d => d.Warehouse)
                    .WithMany()
                    .HasForeignKey(d => d.WarehouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Warehouse");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Sku)
                    .HasName("PK__products__CA1ECF0CBA4B5FEC");

                entity.ToTable("products");

                entity.HasIndex(e => e.ProductName, "UQ__products__DD5A978A323243E4")
                    .IsUnique();

                entity.Property(e => e.Sku)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SKU")
                    .IsFixedLength(true);

                entity.Property(e => e.CollectionId).HasColumnName("CollectionID");

                entity.Property(e => e.Gtin)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GTIN");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Collection)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CollectionId)
                    .HasConstraintName("FK_Product_Collection");
            });

            modelBuilder.Entity<ProductComment>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("productComments");

                entity.Property(e => e.ProductComment1)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ProductComment")
                    .HasDefaultValueSql("('NA')");

                entity.Property(e => e.Sku)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SKU")
                    .IsFixedLength(true);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.SkuNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Sku)
                    .HasConstraintName("FK_Product_Comment");
            });

            modelBuilder.Entity<ProductDescription>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("productDescription");

                entity.Property(e => e.ProductDesc)
                    .HasColumnType("text")
                    .HasDefaultValueSql("('NA')");

                entity.Property(e => e.ProductHighlights)
                    .HasColumnType("text")
                    .HasDefaultValueSql("('NA')");

                entity.Property(e => e.Sku)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SKU")
                    .IsFixedLength(true);

                entity.HasOne(d => d.SkuNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Sku)
                    .HasConstraintName("FK_Product_Description");
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.ToTable("warehouses");

                entity.HasIndex(e => e.WarehouseName, "UQ__warehous__180C89D985018EB1")
                    .IsUnique();

                entity.Property(e => e.WarehouseId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("WarehouseID");

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine3)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RegionId).HasColumnName("RegionID");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.WarehouseName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WarehouseClerk>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("warehouseClerks");

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("employeeID")
                    .IsFixedLength(true);

                entity.Property(e => e.WarehouseId).HasColumnName("warehouseID");

                entity.HasOne(d => d.Warehouse)
                    .WithMany()
                    .HasForeignKey(d => d.WarehouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Warehouse_Clerk");
            });

            modelBuilder.Entity<WarehouseManager>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("warehouseManagers");

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("employeeID")
                    .IsFixedLength(true);

                entity.Property(e => e.WarehouseId).HasColumnName("warehouseID");

                entity.HasOne(d => d.Warehouse)
                    .WithMany()
                    .HasForeignKey(d => d.WarehouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Warehouse_Manager");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
