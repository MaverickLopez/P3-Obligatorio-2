using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.Models.Usuario
{
    public class UsuarioViewModel
    {
        public string Email { get; set; }
        public string Contrasenia { get; set; }
        public string ContraseniaNueva { get; set; }

    }
}
