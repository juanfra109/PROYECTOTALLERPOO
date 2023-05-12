using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TiendaPrueba.Models.dbModels
{
    public partial class Ventum
    {
        public Ventum()
        {
            VentaDetalles = new HashSet<VentaDetalle>();
        }

        [Key]
        public int IdVenta { get; set; }
        public int IdUsuario { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaCompra { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal Total { get; set; }

        [ForeignKey("IdUsuario")]
        [InverseProperty("Venta")]
        public virtual ApplicationUser IdUsuarioNavigation { get; set; } = null!;
        [InverseProperty("IdVentaNavigation")]
        public virtual ICollection<VentaDetalle> VentaDetalles { get; set; }
    }
}
