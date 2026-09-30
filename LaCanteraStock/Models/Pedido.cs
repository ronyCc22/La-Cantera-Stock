using System.ComponentModel.DataAnnotations;

namespace LaCanteraStock.Models
{
    public class Pedido
    {
        [Key]
        public int PedidoID { get; set; }

        public string NumeroBoleta { get; set; }

        public DateTime FechaEmision { get; set; }

        public DateTime FechaEntrega { get; set; }

        public DateTime? FechaEntregaReal { get; set; }

        public int ClienteID { get; set; }

        public byte ModalidadID { get; set; }

        public byte EstadoPedidoID { get; set; }

        public int UsuarioID { get; set; }

        public string Observaciones { get; set; }

        public decimal Total { get; set; }
    }
}