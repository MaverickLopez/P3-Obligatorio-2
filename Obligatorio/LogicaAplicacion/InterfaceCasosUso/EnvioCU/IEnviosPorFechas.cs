using Compartido.DTOs.EnvioDTOs;
using LogicaAplicacion.ImplementacionCasosUso.EnvioCU;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceCasosUso.EnvioCU
{
    public interface IEnviosPorFechas
    {
        List<EnvioPorFechasDTO> Ejecutar(string email, DateTime f1, DateTime f2, int estado);
    }
}
