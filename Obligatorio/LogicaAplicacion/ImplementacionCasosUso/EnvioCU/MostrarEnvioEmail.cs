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
    public class MostrarEnvioEmail : IMostrarEnvioEmail
    {
        private IRepositorioEnvio RepoEnvio { get; set; }

        public MostrarEnvioEmail(IRepositorioEnvio repoEnvio)
        {
            RepoEnvio = repoEnvio;
        }

        public List<EnvioIncompletoDTO> Ejecutar(string email)
        {
            List<Envio> envios = RepoEnvio.GetEnviosPorEmail(email);
            if (envios == null || envios.Count == 0)
            {
                throw new ArgumentException("No hay envios");
            }

            List<EnvioIncompletoDTO> enviosDTO = EnvioMapper.EnvioIncompletoDTOFromEnvio(envios);
            return enviosDTO;
        }
    }
}
