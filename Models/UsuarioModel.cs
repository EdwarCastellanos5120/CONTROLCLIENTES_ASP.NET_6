using System.ComponentModel.DataAnnotations;

namespace CRUDCLIENTES.Models
{
    public class UsuarioModel
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "El Campo es Obligatorio")]
        [EmailAddress(ErrorMessage = "El formato del Correo es Invalido")]
        public string? Correo { get; set; }

        [Required(ErrorMessage = "El Campo es Obligatorio")]
        public string? Clave { get; set; }

        [Required(ErrorMessage = "El Campo es Obligatorio")]
        public string? confirmarClave { get; set; }


    }
}
