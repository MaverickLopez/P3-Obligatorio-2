using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.EnvioDTOs
{
    public class EnvioIncompletoDTO
    {
        public int Id { get; set; }
        public string NumeroTracking { get; set; }
        public string EmpleadoNombre { get; set; }
        public string ClienteNombre { get; set; }
        public double Peso { get; set; }
        public string Estado { get; set; }
    }
}
