using System.ComponentModel.DataAnnotations;

namespace LaCanteraStock.Models
{
    public class Talla
    {
        [Key]
        public short TallaID { get; set; }

        public string Nombre { get; set; }

        public byte Orden { get; set; }
    }
}