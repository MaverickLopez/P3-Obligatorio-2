using Microsoft.AspNetCore.Mvc;
using MVC.Models.Usuario;
using Newtonsoft.Json;

namespace MVC.Controllers
{
    public class AuthController : Controller
    {
        private string url = "";

        public AuthController(IConfiguration configuration)
        {
            url = configuration.GetValue<string>("urlBase") + "/Auth";
        }

        // GET: AuthController/Login
        public IActionResult Login()
        {
            if (HttpContext.Session.GetInt32("LogueadoId") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("NoAutorizado", "Auth");
            }
        }

        // POST: AuthController/HttpPost/Login/5
        [HttpPost]
        public IActionResult Login(UsuarioPreLoginViewModel usuarioVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HttpClient cliente = new HttpClient();
                    Task<HttpResponseMessage> tarea = cliente.PostAsJsonAsync(url, usuarioVM);
                    tarea.Wait();
                    HttpResponseMessage respuesta = tarea.Result;
                    HttpContent contenido = respuesta.Content;
                    Task<string> body = contenido.ReadAsStringAsync();
                    body.Wait();
                    string datos = body.Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        UsuarioLogueadoViewModel usuLogueadoVM = JsonConvert.DeserializeObject<UsuarioLogueadoViewModel>(datos);

                        if (usuLogueadoVM.Rol != "Cliente")
                        {
                            return RedirectToAction("NoAutorizado", "Auth");
                        }

                        if (usuLogueadoVM.Estado == false)
                        {
                            return RedirectToAction("NoAutorizado", "Auth");
                        }

                        HttpContext.Session.SetString("Token", usuLogueadoVM.Token);
                        HttpContext.Session.SetInt32("LogueadoId", usuLogueadoVM.Id);
                        HttpContext.Session.SetString("LogueadoRol", usuLogueadoVM.Rol);
                        HttpContext.Session.SetString("LogueadoEmail", usuLogueadoVM.Email);
                        HttpContext.Session.SetString("LogueadoNombre", usuLogueadoVM.Nombre);
                        HttpContext.Session.SetString("LogueadoApellido", usuLogueadoVM.Apellido);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.msg = datos;
                    }
                }
                else
                {
                    ViewBag.msg = "Datos incorrectos";
                }
            }
            catch (Exception ex)
            {
                ViewBag.msg = "Error";
            }
            return View();
        }

        // GET: AuthController/Logout
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                return RedirectToAction("NoAutorizado", "Auth");
            }
        }

        // GET: AuthController/NoAutorizado
        [HttpGet]
        public IActionResult NoAutorizado()
        {
            return View();
        }


    }
}
