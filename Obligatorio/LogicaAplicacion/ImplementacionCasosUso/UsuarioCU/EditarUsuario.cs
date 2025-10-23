using Compartido.DTOs.UsuarioDTOs;
using Compartido.ExcepcionesGenericas;
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
    public class EditarUsuario : IEditarUsuario
    {
        private IRepositorioUsuario repoUsuario { get; set; }
        public EditarUsuario(IRepositorioUsuario repoUsuario)
        {
            this.repoUsuario = repoUsuario;
        }

        public void Ejecutar(UsuarioDTO usuarioDTO)
        {
            Usuario buscado = repoUsuario.GetByEmailUsuario(usuarioDTO.Email);
            
            if (buscado == null)
            {
                throw new UsuarioException("Datos incorrectos");
            }

            if (buscado.Contrasenia.Valor != usuarioDTO.Contrasenia)
            {
                throw new ConflictException("Datos incorrectos");
            }

            Usuario usuario = UsuarioMapper.UsuarioFromUsuarioDTO(usuarioDTO, buscado);
            usuario.Id = buscado.Id;
            repoUsuario.Editar(usuario);
        }
    }
}
