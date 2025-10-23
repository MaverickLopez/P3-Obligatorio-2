using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Usuario;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Policy;
using System.Net.Http.Json;

namespace MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private string url = "";

        public UsuarioController(IConfiguration configuration)
        {
            url = configuration.GetValue<string>("urlBase") + "/Usuario";
        }
        // GET: UsuarioController/Edit/5
        public ActionResult Edit()
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

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, string contrasenia, string contraseniaNueva)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        UsuarioViewModel usuVM = new UsuarioViewModel
                        {
                            Email = HttpContext.Session.GetString("LogueadoEmail"),
                            Contrasenia = contrasenia,
                            ContraseniaNueva = contraseniaNueva
                        };

                        HttpClient cliente = new HttpClient();
                        cliente.DefaultRequestHeaders.Authorization =
    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));
                        Task<HttpResponseMessage> tarea = cliente.PutAsJsonAsync(url, usuVM);
                        tarea.Wait();
                        HttpResponseMessage respuesta = tarea.Result;

                        if (respuesta.IsSuccessStatusCode)
                        {
                            ViewBag.msg = "Datos cambiados correctamente";
                            return View();
                        }
                        else
                        {
                            HttpContent contenido = respuesta.Content;
                            Task<string> body = contenido.ReadAsStringAsync();
                            body.Wait();
                            ViewBag.msg = body.Result;
                        }
                    }
                    else
                    {
                        ViewBag.msg = "Datos incorrecto";
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.msg = "Error en los datos";
                }
                return View();
            }
            else
            {
                return RedirectToAction("NoAutorizado","Auth");
            }
        }
    }
}
