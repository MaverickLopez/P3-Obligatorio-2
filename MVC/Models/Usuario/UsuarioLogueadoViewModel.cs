namespace MVC.Models.Usuario
{
    public class UsuarioLogueadoViewModel
    {
        public string Token { get; set; }
        public int Id { get; set; }
        public string Rol { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public bool Estado { get; set; }
    }
}
