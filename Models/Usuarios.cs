using System.ComponentModel.DataAnnotations;

namespace TiendaFamiliarMVC.Models
{
    public class Usuarios
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string contrasena { get; set; } 
    }
}
