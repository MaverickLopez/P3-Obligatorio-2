using Compartido.DTOs.EnvioDTOs;
using LogicaAplicacion.InterfaceCasosUso.EnvioCU;
using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvioController : ControllerBase
    {
        private IMostrarEnvioEmail CUMostrarEnvioEmail { get; set; }
        private IEnvioComentarios CUEnvioComentarios { get; set; }
        private IBuscarEnvioNumeroTracking CUBuscarEnvioNumeroTracking { get; set; }
        private IEnviosPorFechas CUEnviosPorFechas { get; set; }
        private IEnviosPorTexto CUEnviosPorTexto { get; set; }

        public EnvioController(IMostrarEnvioEmail cUMostrarEnvioEmail,
            IEnvioComentarios cUEnvioComentarios,
            IBuscarEnvioNumeroTracking cUBuscarEnvioNumeroTracking,
            IEnviosPorFechas cUEnviosPorFechas,
            IEnviosPorTexto cUEnviosPorTexto)
        {
            CUMostrarEnvioEmail = cUMostrarEnvioEmail;
            CUEnvioComentarios = cUEnvioComentarios;
            CUBuscarEnvioNumeroTracking = cUBuscarEnvioNumeroTracking;
            CUEnviosPorFechas = cUEnviosPorFechas;
            CUEnviosPorTexto = cUEnviosPorTexto;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // GET: api/<EnvioController>
        [Authorize(Roles = "Cliente")]
        [HttpGet("BuscarPorEmail/{email}")]
        public IActionResult Get(string email)
        {
            try
            {
                if (email == null)
                {
                    return BadRequest("El email ingresado no es valido");
                }

                List<EnvioIncompletoDTO> listaEnviosDTO = CUMostrarEnvioEmail.Ejecutar(email);

                if (listaEnviosDTO != null)
                {
                    return Ok(listaEnviosDTO);
                }
                else
                {
                    return NotFound("No existen envios");
                }
            }
            catch (EnvioException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Cliente")]
        [HttpGet("Detalles/{id}")]
        public IActionResult Details(int id)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest("El id recibido no es valido");
                }

                EnvioComentariosDTO envioDTO = CUEnvioComentarios.Ejecutar(id);

                if (envioDTO != null)
                {
                    return Ok(envioDTO);
                }
                else
                {
                    return NotFound("No existen envios");
                }
            }
            catch (EnvioException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error");
            }
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // GET api/<EnvioController>/5
        [HttpGet("BuscarPorNumeroTracking/{numeroTracking}")]
        public IActionResult EnvioPorNumeroTracking(string numeroTracking)
        {
            try
            {
                if (numeroTracking == null)
                {
                    return BadRequest("El Numero de tracking recibido no es valido");
                }

                EnvioEnteroDTO envioDTO = CUBuscarEnvioNumeroTracking.Ejecutar(numeroTracking);

                if (envioDTO != null)
                {
                    return Ok(envioDTO);
                }
                else
                {
                    return BadRequest("Datos incorrectos");
                }
            }
            catch (EnvioException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Cliente")]
        [HttpGet("EnvioPorFechas/{email}/{f1}/{f2}/{estado}")]
        public IActionResult EnvioPorFechas(string email, string f1, string f2, int estado)
        {
            try
            {
                if (f1 == null || f2 == null)
                {
                    return BadRequest("Las fechas recibidas no son validas");
                }

                DateTime.TryParse(f1, out DateTime fecha1);
                DateTime.TryParse(f2, out DateTime fecha2);

                List<EnvioPorFechasDTO> envioDTO = CUEnviosPorFechas
                    .Ejecutar(email, fecha1, fecha2, estado);

                if (envioDTO != null)
                {
                    return Ok(envioDTO);
                }
                else
                {
                    return BadRequest("Datos incorrectos");
                }
            }
            catch (EnvioException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Cliente")]
        [HttpGet("EnviosPorTexto/{email}/{texto}")]
        public IActionResult EnviosPorTexto(string email, string texto)
        {
            try
            {
                if (string.IsNullOrEmpty(texto) || string.IsNullOrEmpty(email))
                {
                    return BadRequest("El texto recibido no es valido");
                }

                List<EnvioEnteroDTO> envioDTO = CUEnviosPorTexto.Ejecutar(email, texto);

                if (envioDTO != null)
                {
                    return Ok(envioDTO);
                }
                else
                {
                    return BadRequest("Datos incorrectos");
                }
            }
            catch (EnvioException ex)
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
