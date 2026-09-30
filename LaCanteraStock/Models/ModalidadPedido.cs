using System.ComponentModel.DataAnnotations;

namespace LaCanteraStock.Models
{
    public class ModalidadPedido
    {
        [Key]
        public byte ModalidadID { get; set; }

        public string Nombre { get; set; }
    }
}