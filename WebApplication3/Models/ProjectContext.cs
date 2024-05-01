using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models;

public partial class ProjectContext : DbContext
{
    public ProjectContext()
    {
    }

    public ProjectContext(DbContextOptions<ProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Basket> Baskets { get; set; }

    public virtual DbSet<Consignment> Consignments { get; set; }

    public virtual DbSet<Consignmentlist> Consignmentlists { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Orderlist> Orderlists { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductAvailability> ProductAvailabilities { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductRazdel> ProductRazdels { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<StatusChange> StatusChanges { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseLazyLoadingProxies().UseMySql("server=localhost;user=root;password=root;database=project", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Basket>(entity =>
        {
            entity.HasKey(e => e.IdBasket).HasName("PRIMARY");

            entity.ToTable("basket");

            entity.HasIndex(e => e.IdProduct, "pr_idx");

            entity.HasIndex(e => e.IdCustomer, "usr_idx");

            entity.Property(e => e.IdBasket).HasColumnName("id_basket");
            entity.Property(e => e.IdCustomer).HasColumnName("id_customer");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.IdCustomerNavigation).WithMany(p => p.Baskets)
                .HasForeignKey(d => d.IdCustomer)
                .HasConstraintName("customer");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Baskets)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("prbox");
        });

        modelBuilder.Entity<Consignment>(entity =>
        {
            entity.HasKey(e => e.IdConsignment).HasName("PRIMARY");

            entity.ToTable("consignment");

            entity.HasIndex(e => e.ResponsibleEmployee, "empl_idx");

            entity.HasIndex(e => e.IdProvider, "provider1_idx");

            entity.HasIndex(e => e.Warehouse, "wareho_idx");

            entity.Property(e => e.IdConsignment)
                .ValueGeneratedNever()
                .HasColumnName("id_consignment");
            entity.Property(e => e.DeliveryDate)
                .HasColumnType("datetime")
                .HasColumnName("delivery_date");
            entity.Property(e => e.IdProvider).HasColumnName("id_provider");
            entity.Property(e => e.ResponsibleEmployee).HasColumnName("responsible_employee");
            entity.Property(e => e.Warehouse).HasColumnName("warehouse");

            entity.HasOne(d => d.IdProviderNavigation).WithMany(p => p.Consignments)
                .HasForeignKey(d => d.IdProvider)
                .HasConstraintName("provider1");

            entity.HasOne(d => d.ResponsibleEmployeeNavigation).WithMany(p => p.Consignments)
                .HasForeignKey(d => d.ResponsibleEmployee)
                .HasConstraintName("empl");

            entity.HasOne(d => d.WarehouseNavigation).WithMany(p => p.Consignments)
                .HasForeignKey(d => d.Warehouse)
                .HasConstraintName("wareho");
        });

        modelBuilder.Entity<Consignmentlist>(entity =>
        {
            entity.HasKey(e => e.IdConsignmentlist).HasName("PRIMARY");

            entity.ToTable("consignmentlist");

            entity.HasIndex(e => e.IdConsignmen, "id_consignment_idx");

            entity.HasIndex(e => e.IdProduct, "product_idx");

            entity.Property(e => e.IdConsignmentlist).HasColumnName("id_consignmentlist");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.IdConsignmen).HasColumnName("id_consignmen");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");

            entity.HasOne(d => d.IdConsignmenNavigation).WithMany(p => p.Consignmentlists)
                .HasForeignKey(d => d.IdConsignmen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_consignment");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Consignmentlists)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("product");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.IdCustomer).HasName("PRIMARY");

            entity.ToTable("customer");

            entity.HasIndex(e => e.Login, "login_UNIQUE").IsUnique();

            entity.Property(e => e.IdCustomer)
                .ValueGeneratedNever()
                .HasColumnName("id_customer");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.Firstname)
                .HasMaxLength(150)
                .HasColumnName("firstname");
            entity.Property(e => e.Login)
                .HasMaxLength(45)
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .HasColumnName("password");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(150)
                .HasColumnName("patronymic");
            entity.Property(e => e.Telephone)
                .HasMaxLength(45)
                .HasColumnName("telephone");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.IdEmployee).HasName("PRIMARY");

            entity.ToTable("employee");

            entity.HasIndex(e => e.IdEmployee, "id_employee_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Login, "login_UNIQUE").IsUnique();

            entity.Property(e => e.IdEmployee).HasColumnName("id_employee");
            entity.Property(e => e.Firstname)
                .HasMaxLength(150)
                .HasColumnName("firstname");
            entity.Property(e => e.Gender)
                .HasMaxLength(45)
                .HasColumnName("gender");
            entity.Property(e => e.Login)
                .HasMaxLength(150)
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .HasColumnName("password");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(150)
                .HasColumnName("patronymic");
            entity.Property(e => e.Post)
                .HasMaxLength(150)
                .HasColumnName("post");
            entity.Property(e => e.Telephone)
                .HasMaxLength(45)
                .HasColumnName("telephone");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.IdImage).HasName("PRIMARY");

            entity.ToTable("image");

            entity.HasIndex(e => e.IdProduct, "productph");

            entity.Property(e => e.IdImage).HasColumnName("id_image");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.RouteImage)
                .HasMaxLength(150)
                .HasColumnName("routeImage");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Images)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("productph");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("PRIMARY");

            entity.ToTable("order");

            entity.HasIndex(e => e.Warehouse, "WARE_idx");

            entity.HasIndex(e => e.StatusOrder, "change_st_idx");

            entity.HasIndex(e => e.IdCustomer, "custom_idx");

            entity.Property(e => e.IdOrder).HasColumnName("id_order");
            entity.Property(e => e.DateDelivery).HasColumnName("date_delivery");
            entity.Property(e => e.DateOrder).HasColumnName("date_order");
            entity.Property(e => e.IdCustomer).HasColumnName("id_customer");
            entity.Property(e => e.StatusOrder).HasColumnName("status_order");
            entity.Property(e => e.TotalPrice)
                .HasPrecision(19, 2)
                .HasColumnName("total_price");
            entity.Property(e => e.Warehouse).HasColumnName("warehouse");

            entity.HasOne(d => d.IdCustomerNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdCustomer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("custom");

            entity.HasOne(d => d.StatusOrderNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("change_st");

            entity.HasOne(d => d.WarehouseNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Warehouse)
                .HasConstraintName("WARE");
        });

        modelBuilder.Entity<Orderlist>(entity =>
        {
            entity.HasKey(e => e.Idorderlist).HasName("PRIMARY");

            entity.ToTable("orderlist");

            entity.HasIndex(e => e.IdOrder, "or_idx");

            entity.HasIndex(e => e.IdProduct, "pr_idx");

            entity.Property(e => e.Idorderlist).HasColumnName("idorderlist");
            entity.Property(e => e.IdOrder).HasColumnName("id_order");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.Orderlists)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("or");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Orderlists)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pr2");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PRIMARY");

            entity.ToTable("product");

            entity.HasIndex(e => e.IdCategory, "ctegory_idx");

            entity.HasIndex(e => e.IdProvider, "provider_idx");

            entity.HasIndex(e => e.IdRazdel, "razdel_idx");

            entity.Property(e => e.IdProduct)
                .ValueGeneratedNever()
                .HasColumnName("id_product");
            entity.Property(e => e.Barcode)
                .HasMaxLength(45)
                .HasColumnName("barcode");
            entity.Property(e => e.Color)
                .HasMaxLength(150)
                .HasColumnName("color");
            entity.Property(e => e.Cost)
                .HasPrecision(19, 2)
                .HasColumnName("cost");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IdCategory).HasColumnName("id_category");
            entity.Property(e => e.IdProvider).HasColumnName("id_provider");
            entity.Property(e => e.IdRazdel).HasColumnName("id_razdel");
            entity.Property(e => e.NameProduct).HasColumnName("name_product");
            entity.Property(e => e.Size)
                .HasMaxLength(45)
                .HasColumnName("size");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("ctegory");

            entity.HasOne(d => d.IdProviderNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdProvider)
                .HasConstraintName("provider");

            entity.HasOne(d => d.IdRazdelNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdRazdel)
                .HasConstraintName("razdel");
        });

        modelBuilder.Entity<ProductAvailability>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PRIMARY");

            entity.ToTable("product_availability");

            entity.HasIndex(e => e.IdWarehouse, "warehouse_idx");

            entity.Property(e => e.IdProduct)
                .ValueGeneratedNever()
                .HasColumnName("id_product");
            entity.Property(e => e.IdWarehouse).HasColumnName("id_warehouse");
            entity.Property(e => e.QuantityInStock).HasColumnName("quantity_in_stock");

            entity.HasOne(d => d.IdProductNavigation).WithOne(p => p.ProductAvailability)
                .HasForeignKey<ProductAvailability>(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pr");

            entity.HasOne(d => d.IdWarehouseNavigation).WithMany(p => p.ProductAvailabilities)
                .HasForeignKey(d => d.IdWarehouse)
                .HasConstraintName("warehouse");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.IdproductCategory).HasName("PRIMARY");

            entity.ToTable("product_category");

            entity.Property(e => e.IdproductCategory)
                .ValueGeneratedNever()
                .HasColumnName("idproduct_category");
            entity.Property(e => e.NameCategory)
                .HasMaxLength(150)
                .HasColumnName("name_category");
        });

        modelBuilder.Entity<ProductRazdel>(entity =>
        {
            entity.HasKey(e => e.IdproductRazdel).HasName("PRIMARY");

            entity.ToTable("product_razdel");

            entity.Property(e => e.IdproductRazdel)
                .ValueGeneratedNever()
                .HasColumnName("idproduct_razdel");
            entity.Property(e => e.NameRazdel)
                .HasMaxLength(150)
                .HasColumnName("name_razdel");
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(e => e.IdProvider).HasName("PRIMARY");

            entity.ToTable("provider");

            entity.HasIndex(e => e.IdProvider, "id_provider_UNIQUE").IsUnique();

            entity.Property(e => e.IdProvider).HasColumnName("id_provider");
            entity.Property(e => e.Adress)
                .HasMaxLength(150)
                .HasColumnName("adress");
            entity.Property(e => e.NameOrganization)
                .HasMaxLength(150)
                .HasColumnName("name_organization");
            entity.Property(e => e.Telophone)
                .HasMaxLength(45)
                .HasColumnName("telophone");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.IdStatus).HasName("PRIMARY");

            entity.ToTable("status");

            entity.Property(e => e.IdStatus)
                .ValueGeneratedNever()
                .HasColumnName("id_status");
            entity.Property(e => e.NameStatus)
                .HasMaxLength(50)
                .HasColumnName("name_status");
        });

        modelBuilder.Entity<StatusChange>(entity =>
        {
            entity.HasKey(e => e.IdChange).HasName("PRIMARY");

            entity.ToTable("status_change");

            entity.Property(e => e.IdChange)
                .ValueGeneratedNever()
                .HasColumnName("id_change");
            entity.Property(e => e.DateChange)
                .HasColumnType("datetime")
                .HasColumnName("date_change");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.IdWarehouse).HasName("PRIMARY");

            entity.ToTable("warehouse");

            entity.Property(e => e.IdWarehouse)
                .ValueGeneratedNever()
                .HasColumnName("id_warehouse");
            entity.Property(e => e.Adress)
                .HasMaxLength(45)
                .HasColumnName("adress");
            entity.Property(e => e.WarehouseName)
                .HasMaxLength(45)
                .HasColumnName("warehouse_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
