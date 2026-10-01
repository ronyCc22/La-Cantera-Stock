using System.ComponentModel.DataAnnotations;

namespace LaCanteraStock.Models
{
    public class DetalleConfeccion
    {
        public int DetalleConfeccionID { get; set; }
        public int CategoriaID { get; set; }
        public int TelaID { get; set; }
        public short TallaID { get; set; }
        public byte TipoEstampadoID { get; set; }
        public int Cantidad { get; set; }          
        public string? Observacion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        // Navegaciones
        public Categoria? Categoria { get; set; }
        public Tela? Tela { get; set; }
        public Talla? Talla { get; set; }
        public TipoEstampado? TipoEstampado { get; set; }
    }
}