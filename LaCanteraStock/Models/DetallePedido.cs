using System.ComponentModel.DataAnnotations;

namespace LaCanteraStock.Models
{
    public class DetallePedido
    {
        [Key]
        public int DetallePedidoID { get; set; }

        public int PedidoID { get; set; }

        public int ProductoTallaID { get; set; }

        public string Descripcion { get; set; }

        public int Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal Subtotal { get; set; }
    }
}