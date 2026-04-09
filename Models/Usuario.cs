using System.ComponentModel.DataAnnotations;

namespace TiendaVirtual.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Rol { get; set; }

        [Required]
        [RegularExpression(@"^3\d{9}$",
            ErrorMessage = "El celular debe comenzar con 3 y tener 10 digitos")]
        public string Celular { get; set; }
    }
}