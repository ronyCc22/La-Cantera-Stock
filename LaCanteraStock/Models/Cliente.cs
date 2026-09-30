using System.ComponentModel.DataAnnotations;

namespace LaCanteraStock.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteID { get; set; }

        public string NombreCompleto { get; set; }

        public byte TipoDocumentoID { get; set; }

        public string Documento { get; set; }

        public string Telefono { get; set; }

        public string Direccion { get; set; }
    }
}