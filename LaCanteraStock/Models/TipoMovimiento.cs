using System.ComponentModel.DataAnnotations;

namespace LaCanteraStock.Models
{
    public class TipoMovimiento
    {
        [Key]
        public byte TipoMovimientoID { get; set; }

        public string Nombre { get; set; }
    }
}