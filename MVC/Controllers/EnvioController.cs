using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using MVC.Models.Comentario;
using MVC.Models.Envio;
using MVC.Models.Usuario;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVC.Controllers
{
    public class EnvioController : Controller
    {
        private string url = "";

        public EnvioController(IConfiguration configuration)
        {
            url = configuration.GetValue<string>("urlBase") + "/Envio";
        }


        // GET: EnvioController
        public ActionResult Index()
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                List<EnvioIncompletoViewModel> envioVM = new List<EnvioIncompletoViewModel>();

                try
                {
                    string email = HttpContext.Session.GetString("LogueadoEmail");
                    HttpClient cliente = new HttpClient();
                    cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));
                    Task<HttpResponseMessage> tarea = cliente.GetAsync(url + "/BuscarPorEmail/" + email);
                    tarea.Wait();
                    HttpResponseMessage respuesta = tarea.Result;
                    HttpContent contenido = respuesta.Content;
                    Task<string> body = contenido.ReadAsStringAsync();
                    body.Wait();
                    string datos = body.Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        envioVM = JsonConvert.DeserializeObject<List<EnvioIncompletoViewModel>>(datos);
                    }
                    else
                    {
                        ViewBag.msg = datos;
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Mensaje = "Datos incorrectos";
                }
                return View(envioVM);
            }
            else
            {
                return RedirectToAction("NoAutorizado", "Auth");
            }
        }

        public ActionResult Details(int id)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                EnvioComentariosViewModel envioVM = new EnvioComentariosViewModel();
                try
                {
                    if (int.IsNegative(id))
                    {
                        ViewBag.msg = "Datos incorrectos";
                    }
                    else
                    {
                        HttpClient cliente = new HttpClient();
                        cliente.DefaultRequestHeaders.Authorization =
    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));
                        Task<HttpResponseMessage> tarea = cliente.GetAsync(url + "/Detalles/" + id);
                        tarea.Wait();
                        HttpResponseMessage respuesta = tarea.Result;
                        HttpContent contenido = respuesta.Content;
                        Task<string> body = contenido.ReadAsStringAsync();
                        body.Wait();
                        string datos = body.Result;

                        if (respuesta.IsSuccessStatusCode)
                        {
                            envioVM = JsonConvert.DeserializeObject<EnvioComentariosViewModel>(datos);
                        }
                        else
                        {
                            ViewBag.msg = datos;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.msg = "Error";
                }
                return View(envioVM);
            }
            else
            {
                return RedirectToAction("NoAutorizado", "Auth");
            }
        }

        public ActionResult EnvioPorNumeroTracking()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EnvioPorNumeroTracking(string numero)
        {
            EnvioEnteroViewModel envioVM = new EnvioEnteroViewModel();
            try
            {
                if (string.IsNullOrEmpty(numero))
                {
                    ViewBag.msg = "Datos incorrectos";
                }
                else
                {
                    HttpClient cliente = new HttpClient();
                    Task<HttpResponseMessage> tarea = cliente.GetAsync(url + "/BuscarPorNumeroTracking/" + numero);
                    tarea.Wait();
                    HttpResponseMessage respuesta = tarea.Result;
                    HttpContent contenido = respuesta.Content;
                    Task<string> body = contenido.ReadAsStringAsync();
                    body.Wait();
                    string datos = body.Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        envioVM = JsonConvert.DeserializeObject<EnvioEnteroViewModel>(datos);
                    }
                    else
                    {
                        ViewBag.msg = datos;
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.msg = "Error";
            }
            return View(envioVM);
        }

        public ActionResult EnviosPorFechas()
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("NoAutorizado", "Auth");
            }
        }

        [HttpPost]
        public ActionResult EnviosPorFechas(DateTime f1, DateTime f2, string estado)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                List<EnvioEnteroViewModel> envioVM = new List<EnvioEnteroViewModel>();
                try
                {
                    if (string.IsNullOrEmpty(estado))
                    {
                        ViewBag.msg = "Datos incorrectos";
                    }
                    else
                    {
                        string email = HttpContext.Session.GetString("LogueadoEmail");
                        HttpClient cliente = new HttpClient();
                        cliente.DefaultRequestHeaders.Authorization =
    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));
                        Task<HttpResponseMessage> tarea = cliente.GetAsync(url + "/EnvioPorFechas/" + email + "/" + f1.ToString("yyyy-MM-dd") + "/" + f2.ToString("yyyy-MM-dd") + "/" + estado);
                        tarea.Wait();
                        HttpResponseMessage respuesta = tarea.Result;
                        HttpContent contenido = respuesta.Content;
                        Task<string> body = contenido.ReadAsStringAsync();
                        body.Wait();
                        string datos = body.Result;

                        if (respuesta.IsSuccessStatusCode)
                        {
                            envioVM = JsonConvert.DeserializeObject<List<EnvioEnteroViewModel>>(datos);
                        }
                        else
                        {
                            ViewBag.msg = datos;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.msg = "Error";
                }
                return View(envioVM);
            }
            else
            {
                return RedirectToAction("NoAutorizado", "Auth");
            }
        }

        public ActionResult EnviosPorTexto()
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("NoAutorizado", "Auth");
            }
        }

        [HttpPost]
        public ActionResult EnviosPorTexto(string texto)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                List<EnvioEnteroViewModel> envioVM = new List<EnvioEnteroViewModel>();
                try
                {
                    if (string.IsNullOrEmpty(texto))
                    {
                        ViewBag.msg = "Datos incorrectos";
                    }
                    else
                    {
                        string email = HttpContext.Session.GetString("LogueadoEmail");
                        HttpClient cliente = new HttpClient();
                        cliente.DefaultRequestHeaders.Authorization =
    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));
                        Task<HttpResponseMessage> tarea = cliente.GetAsync(url + "/EnviosPorTexto/" + email + "/" + texto);
                        tarea.Wait();
                        HttpResponseMessage respuesta = tarea.Result;
                        HttpContent contenido = respuesta.Content;
                        Task<string> body = contenido.ReadAsStringAsync();
                        body.Wait();
                        string datos = body.Result;

                        if (respuesta.IsSuccessStatusCode)
                        {
                            envioVM = JsonConvert.DeserializeObject<List<EnvioEnteroViewModel>>(datos);
                        }
                        else
                        {
                            ViewBag.msg = datos;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.msg = "Error";
                }
                return View(envioVM);
            }
            else
            {
                return RedirectToAction("NoAutorizado", "Auth");
            }
        }
    }
}
