using Compartido.DTOs.EnvioDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceCasosUso.EnvioCU
{
    public interface IMostrarEnvioEmail
    {
        List<EnvioIncompletoDTO> Ejecutar(string email);
    }
}
