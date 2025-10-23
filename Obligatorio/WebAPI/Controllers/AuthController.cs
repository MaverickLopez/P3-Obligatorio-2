using Compartido.DTOs.UsuarioDTOs;
using LogicaAplicacion.InterfaceCasosUso.UsuarioCU;
using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebAPI.Autenticacion;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public ILoginUsuario CULogin { get; set; }
        public AuthController(ILoginUsuario cULogin)
        {
            CULogin = cULogin;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public IActionResult Login(UsuarioPreLoginDTO usuarioDTO)
        {
            try
            {
                if (usuarioDTO == null)
                {
                    return BadRequest("Datos incorrectos");
                }

                UsuarioLogueadoDTO usuarioLogueadoDTO = CULogin.Ejecutar(usuarioDTO.Email, usuarioDTO.Contrasenia);

                if (usuarioLogueadoDTO != null)
                {
                    usuarioLogueadoDTO.Token = ManejadorToken.CrearToken(usuarioLogueadoDTO, usuarioDTO.Email);
                    return Ok(usuarioLogueadoDTO);
                }
                else
                {
                    return BadRequest("Datos incorrectos");
                }
            }
            catch (UsuarioException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error");
            }
        }
    }
}
