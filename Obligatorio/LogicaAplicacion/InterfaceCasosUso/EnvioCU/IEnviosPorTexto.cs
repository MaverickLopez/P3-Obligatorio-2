using Compartido.DTOs.EnvioDTOs;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceCasosUso.EnvioCU
{
    public interface IEnviosPorTexto
    {
        List<EnvioEnteroDTO> Ejecutar(string email, string texto);
    }
}
