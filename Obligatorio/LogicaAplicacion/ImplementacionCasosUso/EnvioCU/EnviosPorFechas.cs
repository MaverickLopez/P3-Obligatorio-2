using Compartido.DTOs.EnvioDTOs;
using Compartido.Mappers;
using LogicaAplicacion.InterfaceCasosUso.EnvioCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfaceRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.EnvioCU
{
    public class EnviosPorFechas : IEnviosPorFechas
    {
        private IRepositorioEnvio RepoEnvio { get; set; }
        public EnviosPorFechas(IRepositorioEnvio repoEnvio)
        {
            RepoEnvio = repoEnvio;
        }
        public List<EnvioPorFechasDTO> Ejecutar(string email, DateTime f1, DateTime f2, int estado)
        {
            List<Envio> envios = RepoEnvio.GetEnviosPorFechas(email, f1, f2, estado);

            return EnvioMapper.EnvioToEnvioPorFechasDTO(envios);
        }
    }
}
