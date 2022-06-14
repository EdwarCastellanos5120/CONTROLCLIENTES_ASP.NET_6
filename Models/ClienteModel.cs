using System.ComponentModel.DataAnnotations;

namespace CRUDCLIENTES.Models
{
    public class ClienteModel
    {
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "El Campo Nombre es Obligatorio")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El Campo Apellido es Obligatorio")]
        public string? Apellido { get; set; }

        [Required(ErrorMessage = "El Campo DPI es Obligatorio")]
        [RegularExpression("[0-9]{13}", ErrorMessage = "Numero DPI Invalido (Solo Numericos)")]
        public string? DPI { get; set; }

        [Required(ErrorMessage = "El Campo NIT es Obligatorio")]
        public string? NIT { get; set; }

        [Required(ErrorMessage = "El Campo Telefono es Obligatorio")]
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "El Campo Correo es Obligatorio")]
        [EmailAddress(ErrorMessage = "El formato del Correo es Invalido")]
        public string? Correo { get; set; }
    }

}
