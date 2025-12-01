using System.ComponentModel.DataAnnotations;

namespace FrontendTicketsOnline.Models
{
    public class UsuarioCreateDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(50, ErrorMessage = "El apellido no puede exceder 50 caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        [StringLength(100, ErrorMessage = "El email no puede exceder 100 caracteres")]
        public string Email { get; set; }

        // Recibir la contraseña plana en create; en el servidor la conviertes a hash.
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [MinLength(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres")]
        [StringLength(255, ErrorMessage = "La contraseña no puede exceder 255 caracteres")]
        public string Password { get; set; }

        [Phone(ErrorMessage = "Número de teléfono inválido")]
        [StringLength(20, ErrorMessage = "El teléfono no puede exceder 20 caracteres")]
        public string? Telefono { get; set; }

        // Opcional: si quieres que al crear el usuario se defina el estado (activo/inactivo)
        public bool? Estado { get; set; } = true;

        // No se envía FechaRegistro (se asigna en el servidor).
        [Required(ErrorMessage = "El rol es obligatorio")]
        public int RolId { get; set; }
    }

}
