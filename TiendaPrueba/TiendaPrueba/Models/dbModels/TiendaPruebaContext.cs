using System;
using System.Collections.Generic;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TiendaPrueba.Models.dbModels
{
    public partial class TiendaPruebaContext : IdentityDbContext<ApplicationUser, IdentityRole<int>,int>
    {
        public TiendaPruebaContext()
        {
        }

        public TiendaPruebaContext(DbContextOptions<TiendaPruebaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Carrito> Carritos { get; set; } = null!;
        public virtual DbSet<Deseado> Deseados { get; set; } = null!;
        public virtual DbSet<Marca> Marcas { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Resena> Resenas { get; set; } = null!;
        public virtual DbSet<VentaDetalle> VentaDetalles { get; set; } = null!;
        public virtual DbSet<Ventum> Venta { get; set; } = null!;
        
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carrito>(entity =>
            {
                entity.HasKey(e => new { e.IdUsuario, e.IdProducto });

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Carritos)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Carrito_Producto");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Carritos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Carrito_Usuario");
            });

            modelBuilder.Entity<Deseado>(entity =>
            {
                entity.HasKey(e => new { e.IdUsuario, e.IdProducto });

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Deseados)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Deseados_Producto");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Deseados)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Deseados_Usuario");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdMarca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_Marca");
            });

            modelBuilder.Entity<Resena>(entity =>
            {
                entity.HasKey(e => new { e.IdUsuario, e.IdProducto });

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Resenas)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Resena_Producto");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Resenas)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Resena_Usuario");
            });

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(e => e.Nombre).IsFixedLength();
            });

            

            modelBuilder.Entity<Ventum>(entity =>
            {
                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Venta_Usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
