using System.ComponentModel.DataAnnotations;

namespace LaCanteraStock.Models
{
    public class MetodoPago
    {
        [Key]
        public byte MetodoPagoID { get; set; }

        public string Nombre { get; set; }
    }
}