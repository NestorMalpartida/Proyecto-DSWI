using FE_ProyectoDSWI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace FE_ProyectoDSWI.Controllers
{
    public class ClienteController : Controller
    {

        public async Task<IActionResult> findAll()
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

            return View(await Task.Run(() => lista));
        }

        public async Task<List<Distrito>> findAllDistrito()
        {
            List<Distrito> lista;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7083/api/Distrito");
                HttpResponseMessage response = await client.GetAsync("");

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<Distrito>>(apiResponse);
                }
                else
                {
                    lista = new List<Distrito>();
                }

            }
            return lista;

        }

        public async Task<IActionResult> save()
        {
            ViewBag.listaDistrito = new SelectList(await findAllDistrito(), "codigo", "descripcion");
            return View(await Task.Run(() => new Cliente()));
        }

        [HttpPost]
        public async Task<IActionResult> save(Cliente reg)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7083/api/Cliente");
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
            Cliente reg = new Cliente();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7083/api/Cliente/");
                HttpResponseMessage response = await client.GetAsync(codigo.ToString());

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reg = JsonConvert.DeserializeObject<Cliente>(apiResponse);

                }

                ViewBag.listaDistrito = new SelectList(await findAllDistrito(), "codigo", "descripcion", reg.codigoDistrito);
                return View(await Task.Run(() => reg));

            }

        }
        [HttpPost]
        public async Task<IActionResult> update(Cliente reg)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:7083/api/Cliente/");
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
            ClienteDetalle reg = new ClienteDetalle();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7083/api/ClienteDetalle/");
                HttpResponseMessage response = await client.GetAsync(codigo.ToString());
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reg = JsonConvert.DeserializeObject<ClienteDetalle>(apiResponse);
                }
            }

            return View(reg);
        }
        public async Task<IActionResult> delete(int codigo)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7083/api/Cliente/");
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
