using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TiendaPrueba.Models.dbModels
{
    [Table("Resena")]
    public partial class Resena
    {
        [Key]
        public int IdProducto { get; set; }
        [Key]
        public int IdUsuario { get; set; }
        [StringLength(200)]
        public string Comentario { get; set; } = null!;
        public int Puntuacion { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaCreacion { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaModificacion { get; set; }

        [ForeignKey("IdProducto")]
        [InverseProperty("Resenas")]
        public virtual Producto IdProductoNavigation { get; set; } = null!;
        [ForeignKey("IdUsuario")]
        [InverseProperty("Resenas")]
        public virtual ApplicationUser IdUsuarioNavigation { get; set; } = null!;
    }
}
