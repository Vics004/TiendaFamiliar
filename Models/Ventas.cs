using System.ComponentModel.DataAnnotations;

namespace TiendaFamiliarMVC.Models
{
    public class Ventas
    {
        [Key]
        public int id { get; set; }
        public DateOnly fecha { get; set; }
        public string producto { get; set; }
        public decimal monto { get; set; }
    }
}
