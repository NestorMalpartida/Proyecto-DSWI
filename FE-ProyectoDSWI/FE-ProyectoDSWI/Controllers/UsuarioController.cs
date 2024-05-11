using FE_ProyectoDSWI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace FE_ProyectoDSWI.Controllers
{
    public class UsuarioController : Controller
    {
        public async Task<IActionResult> findAll()
        {
            List<UsuarioDetalle> lista;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7083/api/UsuarioDetalle");
                HttpResponseMessage response = await client.GetAsync("");

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<UsuarioDetalle>>(apiResponse);
                }
                else
                {
                    lista = new List<UsuarioDetalle>();
                }

            }

            return View(await Task.Run(() => lista));
        }

        public async Task<List<Rol>> findAllRol()
        {
            List<Rol> lista;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7083/api/Rol");
                HttpResponseMessage response = await client.GetAsync("");

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<Rol>>(apiResponse);
                }
                else
                {
                    lista = new List<Rol>();
                }

            }
            return lista;

        }

        public async Task<IActionResult> save()
        {
            ViewBag.listaRol = new SelectList(await findAllRol(), "codigo", "descripcion");
            return View(await Task.Run(() => new Usuario()));
        }

        [HttpPost]
        public async Task<IActionResult> save(Usuario reg)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7083/api/Usuario");
                StringContent content = new StringContent(JsonConvert.SerializeObject(reg), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("", content);
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    mensaje = apiResponse;

                }
                ViewBag.mensaje = mensaje;
                return RedirectToAction("findAll");

            }

        }
        public async Task<IActionResult> update(int codigo)
        {
            Usuario reg = new Usuario();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7083/api/Usuario/");
                HttpResponseMessage response = await client.GetAsync(codigo.ToString());

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reg = JsonConvert.DeserializeObject<Usuario>(apiResponse);

                }

                ViewBag.listaRol = new SelectList(await findAllRol(), "codigo", "descripcion", reg.codigoRol);
                return View(await Task.Run(() => reg));

            }

        }
        [HttpPost]
        public async Task<IActionResult> update(Usuario reg)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:7083/api/Usuario/");
                StringContent content = new StringContent(JsonConvert.SerializeObject(reg), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync("codigo", content);
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    mensaje = apiResponse;

                }

                ViewBag.mensaje = mensaje;
                return RedirectToAction("findAll");

            }
        }

        public async Task<IActionResult> details(int codigo)
        {
            UsuarioDetalle reg = new UsuarioDetalle();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7083/api/UsuarioDetalle/");
                HttpResponseMessage response = await client.GetAsync(codigo.ToString());
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reg = JsonConvert.DeserializeObject<UsuarioDetalle>(apiResponse);
                }
            }

            return View(reg);
        }
        public async Task<IActionResult> delete(int codigo)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7083/api/Usuario/");
                HttpResponseMessage response = await client.DeleteAsync(codigo.ToString());

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    mensaje = apiResponse;
                }
            }
            ViewBag.mensaje = mensaje;
            return RedirectToAction("findAll");
        }
    }
}
