using LogicaNegocio.ExcepcionesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Comentario : IEquatable<Comentario>
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int EmpleadoId { get; set; }
        public string TextoComentario { get; set; }

        private Comentario() { }
        public Comentario(DateTime fecha, int empleadoId, string textoComentario)
        {
            Fecha = fecha;
            EmpleadoId = empleadoId;
            TextoComentario = textoComentario;
            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrEmpty(TextoComentario) || string.IsNullOrWhiteSpace(TextoComentario))
            {
                throw new ComentarioException("El texto no puede estar vacio");
            }
        }

        public bool Equals(Comentario? other)
        {
            return Id == other.Id;
        }
    }
}
