using FE_ProyectoDSWI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace FE_ProyectoDSWI.Controllers
{
    public class BoletaController : Controller
    {
        public async Task<IActionResult> findAll()
        {
            List<BoletaDetalle> lista;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7083/api/Boleta");
                HttpResponseMessage response = await client.GetAsync("");

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<BoletaDetalle>>(apiResponse);
                }
                else
                {
                    lista = new List<BoletaDetalle>();
                }

            }

            return View(await Task.Run(() => lista));
        }
        public async Task<List<ClienteDetalle>> findAllCliente()
        {
            List<ClienteDetalle> lista;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7083/api/ClienteDetalle");
                HttpResponseMessage response = await client.GetAsync("");

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<ClienteDetalle>>(apiResponse);
                }
                else
                {
                    lista = new List<ClienteDetalle>();
                }

            }


            return lista;
        }
        public async Task<List<UsuarioDetalle>> findAllUsuario()
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

            return lista;
        }
        public async Task<List<ProductoDetalle>> findAllProducto()
        {
            List<ProductoDetalle> lista;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7083/api/ProductoDetalle");
                HttpResponseMessage response = await client.GetAsync("");

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<ProductoDetalle>>(apiResponse);
                }
                else
                {
                    lista = new List<ProductoDetalle>();
                }

            }

            return lista;
        }
        public async Task<IActionResult> save()
        {
            ViewBag.listaUsuario = new SelectList(await findAllUsuario(), "codigo", "nombre");
            ViewBag.listaCliente = new SelectList(await findAllCliente(), "codigo", "usuario");
            ViewBag.listaProducto = new SelectList(await findAllProducto(), "codigo", "nombre");
            return View(await Task.Run(() => new Boleta()));
        }

        [HttpPost]
        public async Task<IActionResult> save(Boleta reg)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7083/api/Boleta");
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
        public async Task<IActionResult> details(int codigo)
        {
            BoletaDetalle reg = new BoletaDetalle();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7083/api/Boleta/");
                HttpResponseMessage response = await client.GetAsync(codigo.ToString());
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reg = JsonConvert.DeserializeObject<BoletaDetalle>(apiResponse);
                }
            }

            return View(reg);
        }
    }
}
