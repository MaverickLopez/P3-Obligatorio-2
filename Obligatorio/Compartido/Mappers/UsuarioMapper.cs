using Compartido.DTOs.UsuarioDTOs;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Mappers
{
    public class UsuarioMapper
    {
        public static Usuario UsuarioFromUsuarioDTO(UsuarioDTO usuarioDTO, Usuario usuario)
        {
            if (usuarioDTO == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }

            return new Usuario(usuario.Nombre.Valor, usuario.Apellido, usuarioDTO.Email, usuarioDTO.ContraseniaNueva, usuario.Rol);
        }

        public static UsuarioLogueadoDTO UsuarioToUsuarioLogueadoDTO(Usuario usuario)
        {
            if (usuario != null)
            {
                UsuarioLogueadoDTO usuarioEnteroDTO = new UsuarioLogueadoDTO()
                {
                    Id = usuario.Id,
                    Rol = usuario.Rol.ToString(),
                    Nombre = usuario.Nombre.Valor,
                    Apellido = usuario.Apellido,
                    Email = usuario.Email.Valor,
                    Estado = usuario.Estado
                };
                return usuarioEnteroDTO;
            }
            else
            {
                throw new UsuarioException("Credenciales Incorrectas");
            }
        }

    }
}
