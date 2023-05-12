using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TiendaPrueba.Models.dbModels
{
    [Table("Carrito")]
    public partial class Carrito
    {
        [Key]
        public int IdUsuario { get; set; }
        [Key]
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaAñadido { get; set; }

        [ForeignKey("IdProducto")]
        [InverseProperty("Carritos")]
        public virtual Producto IdProductoNavigation { get; set; } = null!;
        [ForeignKey("IdUsuario")]
        [InverseProperty("Carritos")]
        public virtual ApplicationUser IdUsuarioNavigation { get; set; } = null!;
    }
}
