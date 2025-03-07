using System.ComponentModel.DataAnnotations;

namespace TiendaFamiliarMVC.Models
{
    public class Ganancias
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Fecha")]
        public DateOnly fecha { get; set; }
        [Display(Name = "Ventas totales")]
        public decimal total_ventas { get; set; }
        [Display(Name = "Gastos totales")]
        public decimal total_gastos { get; set; }
        [Display(Name = "Ganancia")]
        public decimal ganancia { get; set; }
    }
}
