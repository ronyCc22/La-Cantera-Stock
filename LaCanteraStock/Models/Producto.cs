using System.ComponentModel.DataAnnotations;

namespace LaCanteraStock.Models
{
    public class Producto
    {
        [Key]
        public int ProductoID { get; set; }

        public int CategoriaID { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal PrecioUnitario { get; set; }

        public bool EsConjunto { get; set; }

        public bool Activo { get; set; }
    }
}