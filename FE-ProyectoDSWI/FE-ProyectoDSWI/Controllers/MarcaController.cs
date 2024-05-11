using FE_ProyectoDSWI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace FE_ProyectoDSWI.Controllers
{
    public class MarcaController : Controller
    {
        public async Task<IActionResult> findAll()
        {
            List<MarcaDetalle> lista;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7083/api/MarcaDetalle");
                HttpResponseMessage response = await client.GetAsync("");

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<MarcaDetalle>>(apiResponse);
                }
                else
                {
                    lista = new List<MarcaDetalle>();
                }

            }

            return View(await Task.Run(() => lista));
        }

        public async Task<List<Pais>> findAllPais()
        {
            List<Pais> lista;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7083/api/Pais");
                HttpResponseMessage response = await client.GetAsync("");

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<Pais>>(apiResponse);
                }
                else
                {
                    lista = new List<Pais>();
                }

            }
            return lista;

        }

        public async Task<IActionResult> save()
        {
            ViewBag.listaPais = new SelectList(await findAllPais(), "codigo", "descripcion");
            return View(await Task.Run(() => new Cliente()));
        }

        [HttpPost]
        public async Task<IActionResult> save(Marca reg)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7083/api/Marca");
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
            Marca reg = new Marca();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7083/api/Marca/");
                HttpResponseMessage response = await client.GetAsync(codigo.ToString());

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reg = JsonConvert.DeserializeObject<Marca>(apiResponse);

                }

                ViewBag.listaPais = new SelectList(await findAllPais(), "codigo", "descripcion", reg.codigoPais);
                return View(await Task.Run(() => reg));

            }

        }
        [HttpPost]
        public async Task<IActionResult> update(Marca reg)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:7083/api/Marca/");
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
            MarcaDetalle reg = new MarcaDetalle();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7083/api/MarcaDetalle/");
                HttpResponseMessage response = await client.GetAsync(codigo.ToString());
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reg = JsonConvert.DeserializeObject<MarcaDetalle>(apiResponse);
                }
            }

            return View(reg);
        }
        public async Task<IActionResult> delete(int codigo)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7083/api/Marca/");
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
