using System.ComponentModel.DataAnnotations;

namespace LaCanteraStock.Models
{
    public class ProductoTalla
    {
        [Key]
        public int ProductoTallaID { get; set; }

        public int ProductoID { get; set; }

        public short TallaID { get; set; }

        public int StockActual { get; set; }

        public int StockMinimo { get; set; }
    }
}