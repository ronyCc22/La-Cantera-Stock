using System.ComponentModel.DataAnnotations;

namespace LaCanteraStock.Models
{
    public class EstadoPedido
    {
        [Key]
        public byte EstadoPedidoID { get; set; }

        public string Nombre { get; set; }
    }
}