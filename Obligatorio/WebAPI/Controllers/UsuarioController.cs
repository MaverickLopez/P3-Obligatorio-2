using Compartido.DTOs.UsuarioDTOs;
using Compartido.ExcepcionesGenericas;
using LogicaAplicacion.InterfaceCasosUso.UsuarioCU;
using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Authorize(Roles = "Cliente")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public IEditarUsuario CUEditarUsuario { get; set; }

        public UsuarioController(IEditarUsuario cUEditarUsuario)
        {
            CUEditarUsuario = cUEditarUsuario;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // PUT api/<UsuarioController>/5
        [HttpPut]
        public IActionResult Put([FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                if (usuarioDTO == null)
                {
                    return BadRequest("Datos incorrectos");
                }

                CUEditarUsuario.Ejecutar(usuarioDTO);
                return Ok();
            }
            catch (UsuarioException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ConflictException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno");
            }

        }
    }
}
