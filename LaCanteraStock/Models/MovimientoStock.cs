using System.ComponentModel.DataAnnotations;

namespace LaCanteraStock.Models
{
    public class MovimientoStock
    {
        [Key]
        public int MovimientoID { get; set; }

        public int ProductoTallaID { get; set; }

        public byte TipoMovimientoID { get; set; }

        public int Cantidad { get; set; }

        public DateTime Fecha { get; set; }

        public int? PedidoID { get; set; }

        public int UsuarioID { get; set; }

        public string Observacion { get; set; }
    }
}