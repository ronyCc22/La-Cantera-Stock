using System.ComponentModel.DataAnnotations;

namespace LaCanteraStock.Models
{
    public class Tela
    {
        [Key]
        public int TelaID { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Descripcion { get; set; }

        public bool Activo { get; set; }
    }
}