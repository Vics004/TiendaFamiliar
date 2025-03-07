using System.ComponentModel.DataAnnotations;

namespace TiendaFamiliarMVC.Models
{
    public class Gastos
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Fecha")]
        public DateOnly fecha { get; set; }
        [Display(Name = "Descripción")]
        public string categoria { get; set; }
        [Display(Name = "Monto")]
        public decimal monto { get; set; }
    }
}
