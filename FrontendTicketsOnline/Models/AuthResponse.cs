namespace FrontendTicketsOnline.Models
{
    public class AuthResponse
    {
        public string Token { get; set; }
        public int UsuarioId { get; set; } // si tu API te devuelve el ID del usuario
    }

}
