using LogicaNegocio.ExcepcionesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Auditoria : IEquatable<Auditoria>
    {
        public int Id { get; set; }
        public string Accion { get; set; }
        public DateTime Fecha { get; set; }
        public int IdEmpleado { get; set; }

        private Auditoria() { }
        public Auditoria(string accion, DateTime fecha, int idEmpleado)
        {
            Accion = accion;
            Fecha = fecha;
            IdEmpleado = idEmpleado;
            Validar();
        }
        private void Validar()
        {
            if (string.IsNullOrEmpty(Accion) || string.IsNullOrWhiteSpace(Accion))
            {
                throw new AuditoriaException("La accion no debe estar vacia");
            }
        }

        public bool Equals(Auditoria? other)
        {
            return Id == other.Id;
        }
    }
}
