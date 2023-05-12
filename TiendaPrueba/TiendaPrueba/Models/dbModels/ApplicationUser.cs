using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


namespace TiendaPrueba.Models.dbModels
{
    public class ApplicationUser : IdentityUser<int>
    {
        public ApplicationUser()
        {
            Carritos = new HashSet<Carrito>();
            Deseados = new HashSet<Deseado>();
            Resenas = new HashSet<Resena>();
            Venta = new HashSet<Ventum>();
        }

        [Key]
        public int IdUsuario { get; set; }
        [StringLength(10)]
        public string? Nombre { get; set; }

        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Carrito> Carritos { get; set; }
        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Deseado> Deseados { get; set; }
        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Resena> Resenas { get; set; }
        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
}
