using MVC.Models.Comentario;

namespace MVC.Models.Envio
{
    public class EnvioEnteroViewModel
    {
        public int Id { get; set; }
        public string NumeroTracking { get; set; }
        public string EmpleadoNombre { get; set; }
        public string ClienteNombre { get; set; }
        public double Peso {  get; set; }
        public string Estado { get; set; }
        public List<ComentarioViewModel> Comentarios { get; set; } = new List<ComentarioViewModel>();
    }
}
