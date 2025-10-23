using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.EntidadesNegocio;

namespace Compartido.DTOs.UsuarioDTOs
{
    public class UsuarioDTO
    {
        public string Email { get; set; }
        public string Contrasenia { get; set; }
        public string ContraseniaNueva { get; set; }
    }
}
