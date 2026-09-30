using System.ComponentModel.DataAnnotations;

namespace LaCanteraStock.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaID { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public bool Activo { get; set; }
    }
}