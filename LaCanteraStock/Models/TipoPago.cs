using System.ComponentModel.DataAnnotations;

namespace LaCanteraStock.Models
{
    public class TipoPago
    {
        [Key]
        public byte TipoPagoID { get; set; }

        public string Nombre { get; set; }
    }
}