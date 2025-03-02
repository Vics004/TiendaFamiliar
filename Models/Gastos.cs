using System.ComponentModel.DataAnnotations;

namespace TiendaFamiliarMVC.Models
{
    public class Gastos
    {
        [Key]
        public int id { get; set; }
        public DateOnly fecha { get; set; }
        public string categoria { get; set; }
        public decimal monto { get; set; }
    }
}
