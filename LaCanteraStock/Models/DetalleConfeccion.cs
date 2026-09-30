using System.ComponentModel.DataAnnotations;

namespace LaCanteraStock.Models
{
    public class DetalleConfeccion
    {
        [Key]
        public int DetallePedidoID { get; set; }

        public int CategoriaID { get; set; }

        public int TelaID { get; set; }

        public short TallaID { get; set; }

        public byte TipoEstampadoID { get; set; }

        public string DisenoDescripcion { get; set; }

        public string RutaImagenDiseno { get; set; }
    }
}