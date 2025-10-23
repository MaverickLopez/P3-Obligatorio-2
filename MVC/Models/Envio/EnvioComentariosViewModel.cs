using MVC.Models.Comentario;

namespace MVC.Models.Envio
{
    public class EnvioComentariosViewModel
    {
        public List<ComentarioViewModel> Comentarios { get; set; } = new List<ComentarioViewModel>();
    }
}
