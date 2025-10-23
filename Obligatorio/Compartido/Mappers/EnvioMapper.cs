using Compartido.DTOs.ComentarioDTOs;
using Compartido.DTOs.EnvioDTOs;
using Compartido.DTOs.UsuarioDTOs;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Mappers
{
    public class EnvioMapper
    {
        public static List<EnvioIncompletoDTO> EnvioIncompletoDTOFromEnvio(List<Envio> envios)
        {
            List<EnvioIncompletoDTO> mostrarEnviosDTO = new List<EnvioIncompletoDTO>();

            foreach (Envio e in envios)
            {

                EnvioIncompletoDTO mostrarEnvioDTO = new EnvioIncompletoDTO()
                {
                    Id = e.Id,
                    NumeroTracking = e.NumeroTracking,
                    EmpleadoNombre = e.Empleado.Nombre.Valor,
                    ClienteNombre = e.Cliente.Nombre.Valor,
                    Peso = e.Peso,
                    Estado = e.Estado.ToString()
                };

                mostrarEnviosDTO.Add(mostrarEnvioDTO);
            }
            return mostrarEnviosDTO;
        }

        public static EnvioComentariosDTO EnvioToEnvioComentariosDTO(Envio envio)
        {
            EnvioComentariosDTO envioDTO = new EnvioComentariosDTO()
            {
                Comentarios = envio.Comentario.Select(x => new ComentarioDTO
                {
                    EnvioId = envio.Id,
                    Fecha = x.Fecha,
                    EmpleadoId = x.EmpleadoId,
                    TextoComentario = x.TextoComentario
                }).ToList()
            };

            return envioDTO;
        }

        public static EnvioEnteroDTO EnvioToEnvioEnteroDTO(Envio envio)
        {
            EnvioEnteroDTO envioDTO = new EnvioEnteroDTO()
            {
                Id = envio.Id,
                NumeroTracking = envio.NumeroTracking,
                EmpleadoNombre = envio.Empleado.Nombre.Valor,
                ClienteNombre = envio.Cliente.Nombre.Valor,
                Peso = envio.Peso,
                Estado = envio.Estado.ToString(),
                Comentarios = envio.Comentario.Select(x => new ComentarioDTO
                {
                    EnvioId = envio.Id,
                    Fecha = x.Fecha,
                    EmpleadoId = x.EmpleadoId,
                    TextoComentario = x.TextoComentario
                }).ToList()
            };
            return envioDTO;
        }

        public static List<EnvioPorFechasDTO> EnvioToEnvioPorFechasDTO(List<Envio> envios)
        {
            List<EnvioPorFechasDTO> enviosPorFechasDTO = new List<EnvioPorFechasDTO>();

            foreach (Envio e in envios)
            {

                EnvioPorFechasDTO envioPorFechasDTO = new EnvioPorFechasDTO()
                {
                    NumeroTracking = e.NumeroTracking,
                    Peso = e.Peso,
                    Estado = e.Estado.ToString()
                };

                enviosPorFechasDTO.Add(envioPorFechasDTO);
            }
            return enviosPorFechasDTO;
        }

        public static List<EnvioEnteroDTO> EnviosToEnvioEnteroDTO(List<Envio> envios)
        {
            List<EnvioEnteroDTO> enviosDTO = new List<EnvioEnteroDTO>();
            foreach (Envio e in envios)
            {
                EnvioEnteroDTO envioDTO = new EnvioEnteroDTO()
                {
                    Id = e.Id,
                    NumeroTracking = e.NumeroTracking,
                    EmpleadoNombre = e.Empleado.Nombre.Valor,
                    ClienteNombre = e.Cliente.Nombre.Valor,
                    Peso = e.Peso,
                    Estado = e.Estado.ToString()
                };
                enviosDTO.Add(envioDTO);
            }

            return enviosDTO;
        }
    }
}
