using System.ComponentModel.DataAnnotations;

namespace CentroEmpleados.Models
{
    public class EmpleadoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Nombres es obligatorio")]
        public string? Nombres { get; set; }
        [Required(ErrorMessage = "El campo Apellidos es obligatorio")]
        public string? Apellidos { get; set;}
        [Required(ErrorMessage = "El campo Documento es obligatorio")]
        public int Documento { get; set; }
        
        [Required(ErrorMessage = "El campo Telefono es obligatorio")]
        public int Telefono { get; set; }

        [Required(ErrorMessage = "El campo Correo es obligatorio")]
        public string? Correo { get; set; }
    }
}
