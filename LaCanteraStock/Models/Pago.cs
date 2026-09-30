using System.ComponentModel.DataAnnotations;

namespace LaCanteraStock.Models
{
    public class Pago
    {
        [Key]
        public int PagoID { get; set; }

        public int PedidoID { get; set; }

        public DateTime FechaPago { get; set; }

        public decimal Monto { get; set; }

        public byte TipoPagoID { get; set; }

        public byte MetodoPagoID { get; set; }

        public int UsuarioID { get; set; }

        public string Referencia { get; set; }
    }
}