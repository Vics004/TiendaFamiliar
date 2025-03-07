using System.ComponentModel.DataAnnotations;

namespace TiendaFamiliarMVC.Models
{
    public class Ventas
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Fecha")]
        public DateOnly fecha { get; set; }
        [Display(Name = "Descripción")]
        public string producto { get; set; }
        [Display(Name = "Monto")]
        public decimal monto { get; set; }
    }
}
