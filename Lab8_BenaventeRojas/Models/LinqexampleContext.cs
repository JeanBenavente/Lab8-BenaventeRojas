using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Lab8_BenaventeRojas.Models;

public partial class LinqexampleContext : DbContext
{
    public LinqexampleContext()
    {
    }

    public LinqexampleContext(DbContextOptions<LinqexampleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Clients> Clients { get; set; }

    public virtual DbSet<Orderdetails> Orderdetails { get; set; }

    public virtual DbSet<Orders> Orders { get; set; }

    public virtual DbSet<Products> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=LINQExample;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Clients>(entity =>
        {
            entity.HasKey(e => e.Clientid).HasName("PRIMARY");

            entity.ToTable("clients");

            entity.HasIndex(e => e.Email, "IX_clients_email").IsUnique();

            entity.Property(e => e.Clientid)
                .HasColumnType("int(11)")
                .HasColumnName("clientid");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Orderdetails>(entity =>
        {
            entity.HasKey(e => e.Orderdetailid).HasName("PRIMARY");

            entity.ToTable("orderdetails");

            entity.HasIndex(e => e.Orderid, "FK_orderdetails_orders_orderid");

            entity.HasIndex(e => e.Productid, "FK_orderdetails_products_productid");

            entity.Property(e => e.Orderdetailid)
                .HasColumnType("int(11)")
                .HasColumnName("orderdetailid");
            entity.Property(e => e.Orderid)
                .HasColumnType("int(11)")
                .HasColumnName("orderid");
            entity.Property(e => e.Productid)
                .HasColumnType("int(11)")
                .HasColumnName("productid");
            entity.Property(e => e.Quantity)
                .HasColumnType("int(11)")
                .HasColumnName("quantity");

            entity.HasOne(d => d.Order).WithMany(p => p.Orderdetails)
                .HasForeignKey(d => d.Orderid)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Product).WithMany(p => p.Orderdetails)
                .HasForeignKey(d => d.Productid)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Orders>(entity =>
        {
            entity.HasKey(e => e.Orderid).HasName("PRIMARY");

            entity.ToTable("orders");

            entity.HasIndex(e => e.Clientid, "FK_orders_clients_clientid");

            entity.Property(e => e.Orderid)
                .HasColumnType("int(11)")
                .HasColumnName("orderid");
            entity.Property(e => e.Clientid)
                .HasColumnType("int(11)")
                .HasColumnName("clientid");
            entity.Property(e => e.Orderdate)
                .HasMaxLength(6)
                .HasColumnName("orderdate");

            entity.HasOne(d => d.Client).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Clientid)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Products>(entity =>
        {
            entity.HasKey(e => e.Productid).HasName("PRIMARY");

            entity.ToTable("products");

            entity.Property(e => e.Productid)
                .HasColumnType("int(11)")
                .HasColumnName("productid");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
