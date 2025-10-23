using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfaceRepositorios
{
    public interface IRepositorioEnvio : IRepositorio<Envio>
    {
        public void AltaComentario(int idEnvio, Comentario comentario);
        public Envio GetEnvioPorNumeroTracking(string numeroTracking);
        public List<Envio> GetEnviosPorEmail(string email);
        public Envio GetEnvioComentarios(int envioId);
        public List<Envio> GetEnviosPorFechas(string email, DateTime f1, DateTime f2, int estado);
        public List<Envio> GetEnviosPorComentario(string email, string texto);
    }
}
