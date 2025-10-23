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
    public class EnvioComentarios : IEnvioComentarios
    {
        private IRepositorioEnvio RepoEnvio { get; set; }
        public EnvioComentarios(IRepositorioEnvio repoEnvio)
        {
            RepoEnvio = repoEnvio;
        }
        public EnvioComentariosDTO Ejecutar(int id)
        {
            Envio envio = RepoEnvio.GetEnvioComentarios(id);

            return EnvioMapper.EnvioToEnvioComentariosDTO(envio);
        }
    }
}
