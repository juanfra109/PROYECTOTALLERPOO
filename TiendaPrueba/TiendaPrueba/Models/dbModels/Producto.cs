using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TiendaPrueba.Models.dbModels
{
    [Table("Producto")]
    public partial class Producto
    {
        public Producto()
        {
            Carritos = new HashSet<Carrito>();
            Deseados = new HashSet<Deseado>();
            Resenas = new HashSet<Resena>();
            VentaDetalles = new HashSet<VentaDetalle>();
        }

        [Key]
        public int IdProducto { get; set; }
        [Column("SKU")]
        [StringLength(50)]
        public string Sku { get; set; } = null!;
        [StringLength(50)]
        public string Titulo { get; set; } = null!;
        [StringLength(500)]
        public string Descripcion { get; set; } = null!;
        [Column(TypeName = "decimal(19, 4)")]
        public decimal Precio { get; set; }
        public int? DescuentoPorcentaje { get; set; }
        public int Existencia { get; set; }
        public int IdMarca { get; set; }
        public string? Imagen { get; set; }

        [ForeignKey("IdMarca")]
        [InverseProperty("Productos")]
        public virtual Marca IdMarcaNavigation { get; set; } = null!;
        [InverseProperty("IdProductoNavigation")]
        public virtual ICollection<Carrito> Carritos { get; set; }
        [InverseProperty("IdProductoNavigation")]
        public virtual ICollection<Deseado> Deseados { get; set; }
        [InverseProperty("IdProductoNavigation")]
        public virtual ICollection<Resena> Resenas { get; set; }
        [InverseProperty("IdProductoNavigation")]
        public virtual ICollection<VentaDetalle> VentaDetalles { get; set; }
    }
}
