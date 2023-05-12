using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TiendaPrueba.Models.dbModels
{
    public partial class Deseado
    {
        [Key]
        public int IdUsuario { get; set; }
        [Key]
        public int IdProducto { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaAñadido { get; set; }

        [ForeignKey("IdProducto")]
        [InverseProperty("Deseados")]
        public virtual Producto IdProductoNavigation { get; set; } = null!;
        [ForeignKey("IdUsuario")]
        [InverseProperty("Deseados")]
        public virtual ApplicationUser IdUsuarioNavigation { get; set; } = null!;
    }
}
