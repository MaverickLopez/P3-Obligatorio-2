namespace MVC.Models.Envio
{
    public class EnvioIncompletoViewModel
    {
        public int Id { get; set; }
        public string NumeroTracking { get; set; }
        public string EmpleadoNombre { get; set; }
        public string ClienteNombre { get; set; }
        public double Peso { get; set; }
        public string Estado { get; set; }
    }
}
