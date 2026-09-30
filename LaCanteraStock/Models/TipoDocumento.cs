using System.ComponentModel.DataAnnotations;

namespace LaCanteraStock.Models
{
    public class TipoDocumento
    {
        [Key]
        public byte TipoDocumentoID { get; set; }

        public string Nombre { get; set; }

        public byte Longitud { get; set; }
    }
}