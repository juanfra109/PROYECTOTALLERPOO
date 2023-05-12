using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PIA_PROWEB.Models.dbModels
{
    [Table("idRol")]
    public partial class IdRol
    {
        public IdRol()
        {
            Usuarios = new HashSet<Usuario>();
        }

        [Key]
        [Column("idRol")]
        public int IdRol1 { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Descripción { get; set; } = null!;

        [InverseProperty("IdRolNavigation")]
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
