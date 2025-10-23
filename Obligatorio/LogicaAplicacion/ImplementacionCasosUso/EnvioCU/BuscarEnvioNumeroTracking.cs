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
    public class BuscarEnvioNumeroTracking : IBuscarEnvioNumeroTracking
    {
        private IRepositorioEnvio RepoEnvio { get; set; }
        public BuscarEnvioNumeroTracking(IRepositorioEnvio repoEnvio)
        {
            RepoEnvio = repoEnvio;
        }
        public EnvioEnteroDTO Ejecutar(string numeroTracking)
        {
            Envio envio = RepoEnvio.GetEnvioPorNumeroTracking(numeroTracking);

            if (envio == null)
            {
                throw new EnvioException("Envio no encontrado");
            }

            return EnvioMapper.EnvioToEnvioEnteroDTO(envio);
        }
    }
}
