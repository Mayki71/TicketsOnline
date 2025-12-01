namespace FrontendTicketsOnline.Models
{
    public class RegisterDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Contrasena { get; set; }
        public int RolId { get; set; }
    }
}
