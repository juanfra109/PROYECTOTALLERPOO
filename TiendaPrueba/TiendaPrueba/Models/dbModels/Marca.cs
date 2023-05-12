using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TiendaPrueba.Models.dbModels
{
    [Table("Marca")]
    public partial class Marca
    {
        public Marca()
        {
            Productos = new HashSet<Producto>();
        }

        [Key]
        public int IdMarca { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; } = null!;
        [StringLength(100)]
        public string Descripcion { get; set; } = null!;
        public string? Imagen { get; set; }

        [InverseProperty("IdMarcaNavigation")]
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
