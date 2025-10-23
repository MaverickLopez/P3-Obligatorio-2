using Compartido.DTOs.UsuarioDTOs;
using Compartido.Mappers;
using LogicaAplicacion.InterfaceCasosUso.UsuarioCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfaceRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
    public class LoginUsuario : ILoginUsuario
    {
        private IRepositorioUsuario repoUsuario { get; set; }
        public LoginUsuario(IRepositorioUsuario repoUsuario)
        {
            this.repoUsuario = repoUsuario;
        }
        public UsuarioLogueadoDTO Ejecutar(string email, string contrasenia)
        {
            Usuario usuario = repoUsuario.Login(email, contrasenia);

            if (usuario == null)
            {
                throw new UsuarioException("Credenciales incorrectas");
            }

            return UsuarioMapper.UsuarioToUsuarioLogueadoDTO(usuario);
        }
    }
}
