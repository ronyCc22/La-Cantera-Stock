using System.ComponentModel.DataAnnotations;

namespace LaCanteraStock.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }

        public string NombreUsuario { get; set; }

        public string NombreCompleto { get; set; }

        public string ClaveHash { get; set; }

        public bool Activo { get; set; }
    }
}