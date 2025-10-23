using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfaceRepositorios;
using Microsoft.EntityFrameworkCore;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioEnvioEF : IRepositorioEnvio
    {
        private ObligatorioContext Contexto { get; set; }
        public RepositorioEnvioEF(ObligatorioContext contexto)
        {
            Contexto = contexto;
        }

        public void Alta(Envio item)
        {
            throw new NotImplementedException();
        }

        public void Baja(int id)
        {
            throw new NotImplementedException();
        }

        public void Editar(Envio item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Envio> GetAll()
        {
            throw new NotImplementedException();
        }

        public Envio GetPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void AltaComentario(int idEnvio, Comentario comentario)
        {
            throw new NotImplementedException();
        }

        public Envio GetEnvioPorNumeroTracking(string numeroTracking)
        {
            return Contexto.Envios.Where(t => t.NumeroTracking == numeroTracking)
                .Include(envio => envio.Empleado)
                .Include(envio => envio.Cliente)
                .Include(envio => envio.Comentario)
                .SingleOrDefault();
        }

        public List<Envio> GetEnviosPorEmail(string email)
        {
            return Contexto.Envios.Where(e => e.Cliente.Email.Valor == email)
                .Include(e => e.Empleado)
                .Include(e => e.Cliente)
                .Include(e => e.Comentario)
                .OrderBy(e => e.Comentario[0].Fecha)
                .ToList();
        }

        public Envio GetEnvioComentarios(int envioId)
        {
            return Contexto.Envios.Where(e => e.Id == envioId).Include(e => e.Comentario).SingleOrDefault();
        }

        public List<Envio> GetEnviosPorFechas(string email, DateTime f1, DateTime f2, int estado)
        {
            return Contexto.Envios.Include(e => e.Comentario).Where(e => e.Cliente.Email.Valor == email
            && e.Comentario.Any(c => c.Fecha >= f1 && c.Fecha <= f2)
            && (int)e.Estado == estado)
                .OrderBy(e => e.NumeroTracking)
                .ToList();
        }

        public List<Envio> GetEnviosPorComentario(string email, string texto)
        {
            return Contexto.Envios.Include(e => e.Comentario)
                .Where(e => e.Cliente.Email.Valor == email
                && e.Comentario.Any(c => c.TextoComentario.Contains(texto)))
                .Include(e => e.Empleado)
                .Include(e => e.Cliente)
                .OrderBy(e => e.Comentario[0].Fecha)
                .ToList();
        }
    }
}
