using Compartido.DTOs.EnvioDTOs;
using Compartido.Mappers;
using LogicaAplicacion.InterfaceCasosUso.EnvioCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfaceRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.EnvioCU
{
    public class EnviosPorTexto : IEnviosPorTexto
    {
        private IRepositorioEnvio RepoEnvio { get; set; }
        public EnviosPorTexto(IRepositorioEnvio repoEnvio)
        {
            RepoEnvio = repoEnvio;
        }
        public List<EnvioEnteroDTO> Ejecutar(string email, string texto)
        {
            List<Envio> envios = RepoEnvio.GetEnviosPorComentario(email, texto);

            if (envios == null)
            {
                throw new EnvioException("No hay envios");
            }

            return EnvioMapper.EnviosToEnvioEnteroDTO(envios);
        }
    }
}
