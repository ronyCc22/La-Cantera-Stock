using System.ComponentModel.DataAnnotations;

namespace LaCanteraStock.Models
{
    public class TipoEstampado
    {
        [Key]
        public byte TipoEstampadoID { get; set; }

        public string Nombre { get; set; } = string.Empty;
    }
}